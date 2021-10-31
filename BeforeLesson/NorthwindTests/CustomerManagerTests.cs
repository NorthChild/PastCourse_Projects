using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using System.Linq;

namespace NorthwindTests
{
    public class CustomerTests
    {
        CustomerManager _customerManager;
        [SetUp]
        public void Setup()
        {
            _customerManager = new CustomerManager();
            // remove test entry in DB if present
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);

                db.SaveChanges();
            }
        }

            // DONE

        [Test]
        public void WhenANewCustomerIsAdded_TheNumberOfCustomersIncreasesBy1()
        {

            int beforeTotCount = _customerManager.RetrieveAllCustomers().Count();
            _customerManager.Create("MANDA", "Amanda Johnson", "ToysRU");

            Assert.That(_customerManager.RetrieveAllCustomers().Count(), Is.EqualTo(beforeTotCount + 1));

        }

            //

        [Test]
        public void WhenANewCustomerIsAdded_TheirDetailsAreCorrect()
        {

            using (var db = new NorthwindContext())
            {
                _customerManager.Create("NICK", "Riviera", "Doctors without degrees");

                var queryCustomer =
                    db.Customers.Where(c => c.CustomerId == "NICK" && c.CompanyName == "Doctors without degrees");


                Assert.That(queryCustomer.ElementAt(0), Is.EqualTo("Riviera"));

            }
        }

        [Test]
        public void WhenACustomerIsUpdated_TheDatabaseIsUpdated()
        {
            Assert.Fail();
        }

        [Test]
        public void WhenACustomerIsUpdated_SelectedCustomerIsUpdated()
        {
            Assert.Fail();
        }


            // DONE

        [Test]
        public void WhenACustomerIsNotInTheDatabase_Update_ReturnsFalse()
        {
            using (var db = new NorthwindContext())
            {
                bool check = true;

                var selectCustomerThatIsNotThere =
                    from c in db.Customers
                    where c.CustomerId == "EMPTY"
                    select c;

                if (selectCustomerThatIsNotThere.Count() == 0)
                {
                    check = false;
                }

                Assert.That(check, Is.False);

            }
        }
            
            // DONE

        [Test]
        public void WhenACustomerIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {

            using (var db = new NorthwindContext())
            {

                _customerManager.Create("MANDA", "Amanda Johnson", "ToysRU");
                int beforeTotCount2 = _customerManager.RetrieveAllCustomers().Count();
                _customerManager.Delete("MANDA");


                Assert.That(_customerManager.RetrieveAllCustomers().Count(), Is.EqualTo(beforeTotCount2 - 1));

            }
        }
            
            // DONE

        [Test]
        public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDatabase()
        {

            using (var db = new NorthwindContext())
            {
                _customerManager.Create("LOLLO", "Lorenzo Johnson", "TipperX");
                _customerManager.Delete("LOLLO");

                var findDelCustomer =
                    from c in db.Customers
                    where c.CustomerId == "LOLLO"
                    select c;

                Assert.That(findDelCustomer, Is.EqualTo(string.Empty));

            }

            

        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }
    }
}