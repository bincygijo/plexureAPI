using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace PlexureAPITest
{
    [TestFixture]
    public class Test
    {
      
        Service service;

        [OneTimeSetUp]
        public void Setup()
        {
            service = new Service();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            if (service != null)
            {
                service.Dispose();
                service = null;
            }
        }
        [Test]
        public void TEST_001_Login_With_Valid_User()
        {
           
            var response = service.Login("Tester", "Plexure123");
            response.Expect(HttpStatusCode.OK);
            TestContext.WriteLine("StatusCode is : " + (int)response.StatusCode);
           
        }

        [Test]
        public void TEST_002_Purchase_Product()
        {
            int productId = 1;
            var purchaseP = service.Purchase(productId);
            TestContext.WriteLine("StatusCode is : " + (int)purchaseP.StatusCode);

        }


        [Test]
        public void TEST_003_Get_Points_For_Logged_In_User()
        {
            var points = service.GetPoints();
            TestContext.WriteLine("StatusCode is : " + (int)points.StatusCode);

        }


        [Test]
        public void TEST_004_Login_Without_Username_And_Password()
        {
            var response = service.Login("", "");
            response.Expect(HttpStatusCode.BadRequest);
            TestContext.WriteLine("StatusCode is : " + (int)response.StatusCode);

        }



        [Test]
        public void TEST_005_Login_With_InValid_Username_And_Password()
        {
            var response = service.Login("Testar", "Plexure12");
            response.Expect(HttpStatusCode.Unauthorized);
            TestContext.WriteLine("StatusCode is : " + response.StatusCode);

        }

        [Test]
        public void TEST_006_Get_Point_For_Valid_User()
        {

            var AccessToken = "37cb9e58-99db-423c-9da5-42d5627614c5";
            var points = service.GetPoint(AccessToken);
            TestContext.WriteLine("StatusCode is  : " + (int)points.StatusCode);

        }


    }
}
