using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkingClock
{
    class Program
    {


        static void Main(string[] args)
        {

            /*
                need to work on converting the minutes to words
             */



            Dictionary<int, string> hourInputToWord = new Dictionary<int, string>();            
            hourInputToWord.Add(1, "one");
            hourInputToWord.Add(2, "two");
            hourInputToWord.Add(3, "three");
            hourInputToWord.Add(4, "four");
            hourInputToWord.Add(5, "five");
            hourInputToWord.Add(6, "six");
            hourInputToWord.Add(7, "seven");
            hourInputToWord.Add(8, "eight");
            hourInputToWord.Add(9, "nine");
            hourInputToWord.Add(10, "ten");
            hourInputToWord.Add(11, "eleven");
            hourInputToWord.Add(12, "twelve");

            

            int hourInput;
            int minuteInput;

            bool cont = true;
            bool amOrPM;

            string wordAMorPM;
            

            string time = Console.ReadLine();          
            string[] splitTheTime = separateHourAndMinute(time);

            if (Convert.ToInt32(splitTheTime[0]) > 24 || Convert.ToInt32(splitTheTime[0]) < 0)
            {
                
                Console.WriteLine("Invalid hour. Please provide an hour between 0 to 24. \n Press any key to close the application.");
                Console.ReadLine();
            }
            else if (Convert.ToInt32(splitTheTime[1]) > 59 || Convert.ToInt32(splitTheTime[1]) < 0)
            {
                Console.WriteLine("Invalid Minute. Please provide a minute between 0 to 59. \n Press any key to close the application.");
                Console.ReadLine();
            }
            //for the hours
            else {
                do
                {

                    hourInput = Convert.ToInt32(splitTheTime[0]);

                    if (hourInput > 24 || hourInput < 0)
                    {
                        Console.WriteLine("invalid entry");
                        cont = true;
                    }
                    else
                    {
                        cont = true;
                    }
                    amOrPM = isAMorPM(hourGreaterThan12(hourInput));
                    hourInput = hourGreaterThan12(hourInput);
                    wordAMorPM = (returnAMorPM(amOrPM));

                } while (!cont);



                //for the minutes
                do
                {
                    minuteInput = Convert.ToInt32(splitTheTime[1]);
                    if (minuteInput > 59 || minuteInput < 0)
                    {
                        Console.WriteLine("invalid entry");
                        cont = false;
                    }
                    else
                    {
                        cont = true;
                    }
                } while (!cont);

                Console.Write($"It is {hourInputToWord[hourInput]} {minuteToTextFormat(minuteInput)} {wordAMorPM}");
                Console.ReadLine();
            }
            

        }

        static string[] separateHourAndMinute(string actualTime)
        {

            string[] splitActualTime = actualTime.Split(':');

            return splitActualTime;


        }




        static string minuteToTextFormat(int minute)
        {
            Dictionary<int, string> minuteInputToWord = new Dictionary<int, string>()
            {
                {00, "" },
                {1, "one" },
                {2, "two" },
                {3, "three" },
                {4, "four" },
                {5, "five" },
                {6, "six" },
                {7, "seven" },
                {8, "eight" },
                {9, "nine" },
                {10, "ten" },
                {11, "eleven" },
                {12, "twelve" },
                {13, "thirteen" },
                {14, "fourteen" },
                {15, "fifteen" },
                {16, "sixteen" },
                {17, "seventeen" },
                {18, "eighteen" },
                {19, "nineteen" },
                {20, "twenty " },
                {30, "thirty " },
                {40, "fourty " },
                {50, "fifty " }
            };

            if(minute >= 1 && minute <= 9)
            {
                return "oh " + minuteInputToWord[minute];
            }
            if (minute >= 20 && minute <= 29)
            {
                return minuteInputToWord[20] + minuteInputToWord[(minute - 20)];
            }
            else if (minute >= 30 && minute <= 39)
            {
                return minuteInputToWord[30] + minuteInputToWord[(minute - 30)];
            }
            else if (minute >= 40 && minute <= 49)
            {
                return minuteInputToWord[40] + minuteInputToWord[(minute - 40)];
            }
            else if (minute >= 50 && minute <= 59)
            {
                return minuteInputToWord[50] + minuteInputToWord[(minute - 50)];
            }
            else
            {
                return minuteInputToWord[minute];
            }

           
        }

        static string returnAMorPM(bool pm)
        {

            if (!pm)
            {
                return "pm";
            }
            else
            {
                return "am";
            }
            
        }

        static int hourGreaterThan12(int hour)
        {
            if (hour > 12)
            {
                hour -= 12;
                return hour;
            }
            else
            {
                return hour;
            }
        }

        static bool isAMorPM(int hour)
        {
            if (hour > 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
