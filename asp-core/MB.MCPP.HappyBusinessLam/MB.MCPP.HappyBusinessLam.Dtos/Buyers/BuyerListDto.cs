using MB.MCPP.HappyBusinessLam.Utils.Enums;

namespace MB.MCPP.HappyBusinessLam.Dtos.Buyers
{
    public class BuyerListDto
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public int Discount { get; set; }
    }
}
