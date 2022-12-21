using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfInvoices.Models
{
    public static class Helpers
    {
        public static string getMinValue()
        {
            return "minPocetFaktur =";
        }

        public static string getMaxValue()
        {
            return "maxPocetFaktur =";
        }

        public static int getIntFromString(string input)
        {
            string a = input;
            string b = string.Empty;
            int val = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }

            if (b.Length > 0)
                val = int.Parse(b);

            return val;
        }

        public static string getID(int number)
        {
            if (number >= 1 & number < 10)
            {
                return $"FV000{number}";
            }
            if (number >= 10 & number < 100)
            {
                return $"FV00{number}";
            }
            if (number >= 100 & number < 1000)
            {
                return $"FV0{number}";
            }
            if (number >= 1000 & number < 10000)
            {
                return $"FV{number}";
            }
            return string.Empty;
        }

        public static DateTime getDatetimeOfCreated(int number, DateTime dateTime)
        {
            DateTime dateTimeNew = DateTime.MinValue;
            Random random = new Random();
            if (number == 1)
            {
                int day = random.Next(1, 31);
                dateTimeNew = new DateTime(2021, 1, day);
            }
            else
            {
                int day = random.Next(26);

                if (day == 0)
                {
                    return dateTime;
                }
                else
                {
                    dateTimeNew = dateTime;
                    dateTimeNew = dateTimeNew.AddDays(day);
                }
            }

            return dateTimeNew;

        }
    }
}
