using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSampleProject.Model
{
    public class Order
    {
        public int Id { get; set; } //Ik zie op internet idd OrderId staan, maar omdat dit in de klasse order is zou ik het gewoon Id maken
        public DateTime ExpectedDeliveryDate { get; set; } //Ik zou dit ExpectedDeliveryDate noemen
        public int OrderNumber { get; set; }
        //dan krijg je dit
        public int PersonId { get; set; } //Hier kom ik zo op terug
    }
}
