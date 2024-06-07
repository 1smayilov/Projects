using System;
using System.Text;

namespace Reqemler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Ədəd daxil edin:");
            long reqem = long.Parse(Console.ReadLine()); 

            string netice = ReqemiHerfeCevir(reqem);

            Console.WriteLine(netice);
        }

        static string ReqemiHerfeCevir(long reqem) 
        {
            string[] tekler = { "", "bir", "iki", "üç", "dörd", "beş", "altı", "yeddi", "səkkiz", "doqquz" };
            string[] onlar = { "", "on", "iyirmi", "otuz", "qırx", "əlli", "altmış", "yetmiş", "səksən", "doxsan" };
            string[] yuzler = { "", "yüz" };
            string[] minler = { "", "min" };
            string[] milyonlar = { "", "milyon" };
            string[] milyardlar = { "", "milyard" };

            string netice = "";

            if (reqem >= 1000000000)
            {
                netice += ReqemiHerfeCevir(reqem / 1000000000) + " " + milyardlar[1] + " ";
                reqem %= 1000000000;
            }

            if (reqem >= 1000000)
            {
                netice += ReqemiHerfeCevir(reqem / 1000000) + " " + milyonlar[1] + " ";
                reqem %= 1000000;
            }

            if (reqem >= 1000)
            {
                netice += ReqemiHerfeCevir(reqem / 1000) + " " + minler[1] + " ";
                reqem %= 1000;
            }

            if (reqem >= 100)
            {
                if (reqem / 100 == 1)
                    netice += yuzler[1] + " ";
                else
                    netice += tekler[reqem / 100] + " " + yuzler[1] + " ";
                reqem %= 100;
            }

            if (reqem >= 10)
            {
                netice += onlar[reqem / 10] + " ";
                reqem %= 10;
            }

            if (reqem > 0)
            {
                netice += tekler[reqem] + " ";
            }

            return netice.Trim();
        }
    }
}
