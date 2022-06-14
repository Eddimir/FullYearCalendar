using System;
using System.Linq;
using System.Collections.Generic;
namespace FullYearCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
             DrawingCalendarFullYear();           
        }
        public static void DrawingCalendarFullYear()
        {
            int year = DateTime.Now.Year;

           // Loop 12 times (once for each month)
           for (int i = 1; i < 13; i++)
           {
               // Get the first day of the current month
               var month = new DateTime(year, i, 1);

               // Print out the month, year, and the days of the week   
               // headingSpaces is calculated to align the year to the right side   
               var headingSpaces = new string(' ', 16 - month.ToString("MMMM").Length);
               Console.WriteLine($"{month.ToString("MMMM").ToUpper()}{headingSpaces}{month.Year}");
               Console.WriteLine(new string('-', 20));
               Console.WriteLine("Do Lu Ma Mi Ju Vi Sa");               
               // Get the number of days we need to leave blank at the 
               // start of the week. 
               var padLeftDays = (int)month.DayOfWeek;
               var currentDay = month;
 
               // Print out the day portion of each day of the month
               // iterations is the number of times we loop, which is the number
               // of days in the month plus the number of days we pad at the beginning
              var iterations = DateTime.DaysInMonth(month.Year, month.Month) + padLeftDays;
              for (int j = 0; j < iterations; j++)
              {
                 // Pad the first week with empty spaces if needed
                 if (j < padLeftDays)
                 {
                     Console.Write("   ");
                 }
                 else
                 {               
                     bool any = ListDiasFeriados().Any(x=> x.Dia == currentDay.Day && x.Mes == currentDay.Month);

                     if(any)
                     {
                        Console.ForegroundColor = ConsoleColor.Red;
                     }
                     else if(currentDay.Day == DateTime.Now.Day 
                            && currentDay.Month == DateTime.Now.Month)
                     {
                           //Dia actual 
                           Console.ForegroundColor = ConsoleColor.Yellow;
                     }
                     else
                     {
                        Console.ForegroundColor = ConsoleColor.White;
                     }
                     
                     // Write the day - pad left adds a space before single digit days  
                     Console.Write($"{currentDay.Day.ToString().PadLeft(2, ' ')} ");

                     // If we've reached the end of a week, start a new line
                     if ((j + 1) % 7 == 0)
                     {
                        Console.WriteLine();
                     }
                     // Increment our 'currentDay' to the next day
                     currentDay = currentDay.AddDays(1);
                 }
             }            
             // Put a blank space              
              Console.WriteLine("\n");
              
              }

          // Console.WriteLine("Un total de " + ListDiasFeriados().Count() + " dias feriados en el año "+DateTime.Now.Year);
        }

        public static List<DiasFeriados> ListDiasFeriados(){
            return new List<DiasFeriados>(){
                new DiasFeriados {Dia = 1, Mes = 1},
                new DiasFeriados {Dia = 6, Mes = 1},
                new DiasFeriados {Dia = 21, Mes = 1},
                new DiasFeriados {Dia = 26, Mes = 1},
                new DiasFeriados {Dia = 27, Mes = 2},
                new DiasFeriados {Dia = 10, Mes = 4},
                new DiasFeriados {Dia = 4,  Mes = 5},
                new DiasFeriados {Dia = 11, Mes = 6},
                new DiasFeriados {Dia = 16, Mes = 8},
                new DiasFeriados {Dia = 24, Mes = 9},
                new DiasFeriados {Dia = 9, Mes = 11},
                new DiasFeriados {Dia = 25, Mes = 12}
            };
        }

       public class DiasFeriados {
            public int Dia {get;set;}
            public int Mes {get;set;}
        }
    }
}
