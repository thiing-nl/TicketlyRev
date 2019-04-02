namespace Screend.Models.Order
{
    public class MollieAmountDTO
    {
        public string currency { get; set; } = "EUR";
        public string value { get; set; }
    }
    
    public class MolliePaymentDTO
    {
        public string description { get; set; }
        public string redirectUrl { get; set; }
        public MollieAmountDTO amount { get; set; }
    }
}