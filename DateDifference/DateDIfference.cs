using System;
namespace DateDifference
{
    public class DateDifference
    {
        private static int Years { get; set; } = 1;
        private static int YearCombined { get; set; } = Years;
        
        public static DateCalculationResult Calculate(DateTime from, DateTime to)
        {
            Years = from.Year;
            if (from > to)
            {
                
            }
            else
            {
                var cache = from;
                from = to;
                to = cache;
            }
            
            TimeSpan timeSpan = from.Subtract(to);
            int monthsn = 0;
            int days = timeSpan.Days;
            while (days > 27)
            {
                YearCombined = from.Year - currentYear;
                if (firstrun)
                {
                    current = from.Month - 1;
                }
                if (current == -1)
                {
                    current = 11;
                    currentYear++;
                }
                int daysq = 0;
                if (monthDay[current] == 28)
                {
                    if (DateTime.IsLeapYear(YearCombined))
                    {
                        daysq = 29;
                    }
                    else
                    {
                        daysq = 28;
                    }
                }
                else
                {
                    daysq = monthDay[current];
                }
                if (daysq >= monthDay[current])
                {
                    days -= daysq;
                    monthsn++;
                }

                firstrun = false;
                current--;

            }
            int years = monthsn / 12;
            int months = monthsn - years * 12;
            return new DateCalculationResult(years, months, days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

        }

        private static bool firstrun { get; set; } = true;
        
        private static int[] monthDay = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30,
            31 };
        
        private static int current { get; set; } = 0;
        
        private static int currentYear { get; set; } = 0;
    }
    public class DateCalculationResult
    {
        public DateCalculationResult(int Years, int Months, int Days, int Hours, int Minutes, int Seconds, int MilliSeconds)
        {
            this.Years = Years;
            this.Months = Months;
            this.Days = Days;
            this.Hours = Hours;
            this.Minutes = Minutes;
            this.Seconds = Seconds;
            this.MilliSeconds = MilliSeconds;
        }
        
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int MilliSeconds { get; set; }
    } 
}