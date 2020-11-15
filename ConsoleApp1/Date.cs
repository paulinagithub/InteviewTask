using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Date
    {
        public const int MaxYear = 2099;
        public const int MinYear = 2001;
        public const int MaxMonth = 12;
        public const int MinMonth = 1;
        public const int MaxDay = 31;
        public const int MinDay = 1;
        public const int February = 2;
        public const int April = 4;
        public const int June = 6;
        public const int October = 8;
        public const int November = 11;

        public bool DateValidation(int day, int month, int year)
        {
            if (CheckIfYearIsInRange(year) || 
                CheckIfMonthIsInRange(month) || 
                CheckIfDayIsInRange(day) || 
                !CheckIfNumberOfDaysInMonthIsCorrect(day, month, year)
                )
                return false;

            return true;
        }

        private bool CheckIfNumberOfDaysInMonthIsCorrect(int day, int month, int year)
        {
            if (month == February)
                return CheckNumberOfDaysInFebruary(day, year);

            else if (month == April || month == June || month == October || month == November)
                return CheckIfNumberOfDaysIsLessThan30(day);

            return true;
        }
        private bool CheckIfNumberOfDaysIsLessThan30(int day)
        {
            return (day <= 30);
        }
        private bool CheckNumberOfDaysInFebruary(int day,int year)
        {
            return CheckIfLeapYear(year) ? (day <= 29) : (day <= 28);
        }
        private bool CheckIfYearIsInRange(int year)
        {
            return (year < MinYear || year > MaxYear);
        }
        private bool CheckIfMonthIsInRange(int month)
        {
            return (month < MinMonth || month > MaxMonth);
        }
        private bool CheckIfDayIsInRange(int day)
        {
            return (day < MinDay || day > MaxDay);
        }
        private bool CheckIfLeapYear(int year)
        {
            return (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0));
        }
    }
}
