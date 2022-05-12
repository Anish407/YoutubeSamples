using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSamples.Nested_FluentValidation
{
    public class Customer
    {
        public string CustId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime  Dob { get; set; }

        public IList<Orders> Orders { get; set; }
    }

    public class Orders
    {
        public string OrderName { get; set; }
        public Guid OrderId { get; set; }

        public Category Category { get; set; }


    }

    public class Category
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }



}
