using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EF_ModelFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SouthwindContext())
            {

            }



            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] list2 = new int[] { 9, 8, 6, 5 };

            Customer jerry = new Customer() { CustomerId = "JERRY", ContactName = "Jerry Smith", City = "New Mexico", PostalCode = "RNM"};
            Order order1 = new Order() {  };


            














        }
    }
}
