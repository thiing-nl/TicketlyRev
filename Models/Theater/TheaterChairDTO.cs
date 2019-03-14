namespace Screend.Models.Theater
{
    public enum ChairType
    {
        FREE = 0,
        OCCUPIED = 1
    }
    public class TheaterChairDTO
    {
        public int Id { get; set; }
        public int ChairNumber { get; set; }
//        public ChairType IsFree { get; set; }
    }
}