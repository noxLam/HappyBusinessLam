using MB.MCPP.HappyBusinessLam.Utils.Enums;

namespace MB.MCPP.HappyBusinessLam.Dtos.Deals
{
    public class DealDto
    {
        public DealDto()
        {
            DrugIds = new List<int>();
        }

        public int Id { get; set; }
        public PaymentType PaymentType { get; set; }


        public int BuyerId { get; set; }

        public int PharmacistId { get; set; }
        

        public List<int> DrugIds { get; set; }
    }
}
