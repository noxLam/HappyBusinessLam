using MB.MCPP.HappyBusinessLam.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.MCPP.HappyBusinessLam.Entities
{
    public class Buyer
    {


        public Buyer()
        {
            Deals = new List<Deal>();
        }

        public int Id { get; set; }
        public string CodeName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public int Discount { get; set; }

        public List<Deal> Deals { get; set; }


        [NotMapped]
        public int Age
        {
            get
            {
                if (DOB.HasValue)
                {
                    return DateTime.Now.Year - DOB.Value.Year;
                }
                else
                {
                    return -1;
                }
            }
        }

        [NotMapped]
        public string DiscountInPercentage
        {
            get
            {
                return $"% {Discount}";
            }
        }
    }
}
