using MB.MCPP.HappyBusinessLam.Utils.Enums;

namespace MB.MCPP.HappyBusinessLam.Dtos.Deals
{
    public class DealDetailsDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DealTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public Guid TransactionCode { get; set; }


        public int BuyerId { get; set; }

        public int PharmacistId { get; set; }
    }
}
