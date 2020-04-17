using FireAlarmService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestDataApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<UserModel> userList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("users/").Result;
            userList = response.Content.ReadAsAsync<IEnumerable<UserModel>>().Result;
          //  var sb = new StringBuilder();

            foreach (var row in userList)
            {
                //UserModel userModel = new UserModel();
                Console.WriteLine(row.Name.ToString());
                Console.WriteLine(row.Email.ToString());
            }
            Console.WriteLine(Convert.ToInt32(response.StatusCode));

            Console.ReadLine();
        }

        public void viewUsers()
        {


           
        }
    }
}
