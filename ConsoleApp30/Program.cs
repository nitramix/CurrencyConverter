using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;




namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://apilayer.net/api/live? access_key=8efc5a54419e913b695f694bbef4d97f& currencies = EUR,GBP,CAD,PLN,MKD& source = USD& format = 1";
            string objects = new WebClient().DownloadString(url);
            var currency = JsonConvert.DeserializeObject<RootObject>(objects);


            var USDEUR = currency.quotes.USDEUR;
            var USDMKD = currency.quotes.USDMKD;
            var USDGBP = currency.quotes.USDGBP;
            var USDCAD = currency.quotes.USDCAD;
            var USDCHF = currency.quotes.USDCHF;


            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        

            bool MainMenu()
            {
                Console.WriteLine("Choose currency what you want to calculate to Macedonian Denar");
                Console.WriteLine("1: USD");
                Console.WriteLine("2: EUR");
                Console.WriteLine("3: CAD");
                Console.WriteLine("4: GBP");
                Console.WriteLine("5: CHF");
                Console.WriteLine("6: Exit");

                int choose = Int32.Parse(Console.ReadLine());

                if(choose == 1)
                {
                    Console.WriteLine("Insert amount in USD");
                    var amount = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " USD are " + Math.Round(amount * USDMKD, 2) + " MKD");
                    return true;
                }
                else if(choose == 2)
                {
                    Console.WriteLine("Insert amount in EUR");
                    var amount = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " EUR are " + Math.Round((amount * USDMKD) / USDEUR, 2) + " MKD");
                    return true;
                }
                else if (choose == 3)
                {
                    Console.WriteLine("Insert amount in CAD");
                    var amount = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " CAD are " +Math.Round(amount * USDMKD / USDCAD, 2) + " MKD");
                    return true;
                }
                else if (choose == 4)
                {
                    Console.WriteLine("Insert amount in GBP");
                    var amount = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " GBP are " +Math.Round((amount * USDMKD) / USDGBP,2) + " MKD");
                    return true;
                }
                else if (choose == 5)
                {
                    Console.WriteLine("Insert amount in CHF");
                    var amount = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " CHF are " + Math.Round((amount * USDMKD) / USDCHF, 2) + " MKD");
                    return true;
                }
                else if(choose == 6)
                {
                   Environment.Exit(0);
                    return false;
                }
                else
                {
                    Console.WriteLine("Choose valid option");
                    return true;
                }
                
            }

            


         

            Console.ReadLine();


        }

    }
    
}

