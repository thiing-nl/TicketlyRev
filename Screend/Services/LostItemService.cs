using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Screend.Entities.LostItem;
using Screend.Exceptions;
using Screend.Models.Location;
using Screend.Models.LostItem;
using Screend.Repositories;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Screend.Services
{
    public interface ILostItemService
    {
        IEnumerable<LostItem> GetAll(int locationId);
        LostItem GetById(int id);
        LostItem Create(LostItemCreateUpdateDTO lostItem, int locationId, bool sendSms = true);
        LostItem Update(int id, LostItemCreateUpdateDTO lostItemCreateUpdate, bool sendSms = true);
        void Delete(int id);
    }
    
    public class LostItemService : BaseService, ILostItemService
    {
        private readonly ILostItemRepository _lostItemRepository;
        private readonly IConfiguration _configuration;

        public LostItemService(ILostItemRepository lostItemRepository, IConfiguration configuration)
        {
            _lostItemRepository = lostItemRepository;
            _configuration = configuration;

            if (_configuration["twilioAccountSid"] != null && _configuration["twilioAuthToken"] != null)
            {
                TwilioClient.Init(_configuration["twilioAccountSid"], _configuration["twilioAuthToken"]);
            }
        }
        
        public IEnumerable<LostItem> GetAll(int locationId)
        {
            return _lostItemRepository
                .GetAllByLocationId(locationId)
                .ToArray();
        }

        public LostItem GetById(int id)
        {
            var lostItem = _lostItemRepository
                .GetByID(id);

            if (lostItem == null)
            {
                throw new NotFoundException("Lost Item not found");
            }

            return lostItem;
        }

        public LostItem Create(LostItemCreateUpdateDTO lostItem, int locationId, bool sendSms = true)
        {
            var mappedLostItem = Mapper.Map<LostItem>(lostItem);
            mappedLostItem.LocationId = locationId;
            _lostItemRepository.Insert(mappedLostItem);
            _lostItemRepository.Commit();

            if (!sendSms || lostItem.PhoneNumber.Trim().Equals("")) 
                return mappedLostItem;

            var locationMinimal = Mapper.Map<LocationMinimalDTO>(mappedLostItem.Location);
            SendMessage($"Hi, We're sorry you lost an item at our cinema in {locationMinimal.Name}, we'll check in with an employee and will send you a message once they start searching for the item. \n\n- Ticketly", mappedLostItem.PhoneNumber);
            
            return mappedLostItem;
        }

        public LostItem Update(int id, LostItemCreateUpdateDTO lostItemCreateUpdate, bool sendSms = true)
        {
            var lostItem = GetById(id);
            Mapper.Map(lostItemCreateUpdate, lostItem);
            _lostItemRepository.Commit();
            
            if (!sendSms || lostItem.PhoneNumber.Trim().Equals("")) 
                return lostItem;

            switch (lostItemCreateUpdate.State)
            {
                case LostItemState.Searching:
                    SendMessage("Hi, Just wanted to let you know a employee is currently looking for the item. They may call you for more information.", lostItem.PhoneNumber);
                    break;
                case LostItemState.Found:
                    SendMessage($"Hi, Great news. The item has been found, you can retrieve your item at the ticket desk in {lostItem.Location.Name}.", lostItem.PhoneNumber);
                    break;
                case LostItemState.Halted:
                    SendMessage("Hi, We've looked everywhere and we concluded it would be best to halt the search for now. We'll keep an eye out for the item and ask around. If it turns up we'll let you know. If you have any more questions feel free to call us.", lostItem.PhoneNumber);
                    break;
            }

            return lostItem;
        }

        private void SendMessage(string message, string phoneNumber)
        {
            var smsMessage = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(_configuration["twilioFromPhoneNumber"]),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
                
            Console.WriteLine(smsMessage.Sid);
        }

        public void Delete(int id)
        {
            var lostItem = GetById(id);
            
            _lostItemRepository.Delete(lostItem);
            _lostItemRepository.Commit();
        }
    }
}