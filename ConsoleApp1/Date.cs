using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     * Napisz funkcję sprawdzającą poprawność daty w latach 2001-2099 (daty spoza tego okresu uznaj za
niepoprawne).
Wejście – trzy parametry liczbowe (dzień, miesiąc, rok).
Wyjście – parametr logiczny (true – data poprawna, false – data niepoprawna) .
Proszę zaimplementować własny algorytm kontroli – nie wolno korzystać z gotowych rozwiązań, np.
LocalDate, Calendar, itp.
    */
    class Date
    {
        public const int MaxYear = 2099;
        public const int MinYear = 2001;
        public const int MaxMonth = 12;
        public const int MinMonth = 1;
        public const int MaxDay = 31;
        public const int MinDay = 1;
        public bool DateValidation(int day, int month, int year)
        {
            if (CheckIfYearIsVaild(year) || CheckIfMonthIsValid(month) || CheckIfDayIsValid(day))
                return false;
  
            if (month == 2)
            {
                if (!HandleNumberOfDaysInFebruary(day, year))
                    return false;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
                return HandleNumbersOfDaysLessThan30(day);

            return true;
        }

        public bool HandleNumbersOfDaysLessThan30(int day)
        {
            return (day <= 30);
        }
        public bool HandleNumberOfDaysInFebruary(int day,int year)
        {          
            if (CheckIfLeapYear(year))
                return (day <= 29);
            else
                return (day <= 28);
        }
        public bool CheckIfYearIsVaild(int year)
        {
            return (year < MinYear || year > MaxYear);
        }
        public bool CheckIfMonthIsValid(int month)
        {
            return (month < MinMonth || month > MaxMonth);
        }
        public bool CheckIfDayIsValid(int day)
        {
            return (day < MinDay || day > MaxDay);
        }
        public bool CheckIfLeapYear(int year)
        {
            return (((year % 4 == 0) &&
                 (year % 100 != 0)) ||
                 (year % 400 == 0));
        }
    }




}
