using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.MCPP.HappyBusinessLam.Entities
{
    public class Classification
    {
        public Classification()
        {
            Drugs = new List<Drug>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Drug> Drugs { get; set; }
    }
}
