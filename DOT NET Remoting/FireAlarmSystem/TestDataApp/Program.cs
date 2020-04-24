using FireAlarmService;
using FireAlarmService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDataApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Usermodel> userList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("room/").Result;
            userList = response.Content.ReadAsAsync<IEnumerable<Usermodel>>().Result;
          //  var sb = new StringBuilder();



            foreach (var row in userList)
            {
                
                Console.WriteLine("Room no: " +row.RoomNo.ToString()+ "==== Floor No : " +row.FloorNo.ToString());
                Console.WriteLine("C02 Alarm: " + row.IsCO2Active.ToString() + "==== Smoke Alarm : " + row.IsSmokeActive.ToString());
                Console.WriteLine("CO2 Level: " + row.Co2Level.ToString() + "==== Smoke : " + row.SmokeLevel.ToString());


            }
            //Console.WriteLine(Convert.ToInt32(response.StatusCode));
           // Console.WriteLine(userList.ToList().Count);
           // Console.WriteLine(userList);
            Console.ReadLine();


     
        }

        internal static void Run()
        {
            int seconds = 5 * 1000;

            var timer = new Timer(TimerMethod, null, 0, seconds);

            Console.ReadKey();
        }

        private static void TimerMethod(object o)
        {
            Console.WriteLine(
                "Running: " + DateTime.Now);
        }

        public void viewUsers()
        {


           
        }
    }

    class CallMethodEvery5Seconds
    {
       
    }
}
