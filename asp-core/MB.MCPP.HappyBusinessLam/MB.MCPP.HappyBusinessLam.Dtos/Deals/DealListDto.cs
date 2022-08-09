namespace MB.MCPP.HappyBusinessLam.Dtos.Deals
{
    public class DealListDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DealTime { get; set; }


        public string BuyerCodeName { get; set; }

        public string PharmacistFirstName { get; set; }
    }
}
