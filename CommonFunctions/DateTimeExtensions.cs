using System.Text;

namespace CommonFunctions
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> To(this DateTime from, DateTime to, bool includeNonBusinessDays)
        {
            if (from > to)
                throw new ArgumentException(string.Format("Invalid date range: from date ({0}) is greater than the to date {1}.",
                    from.ToShortDateString(), to.ToShortDateString()));
            Func<DateTime, DateTime> func = lmb => includeNonBusinessDays ? lmb.AddDays(1) : lmb.AddBusinessDays(1);
            List<DateTime> dates = new List<DateTime>();
            DateTime dt = from;
            do
            {
                //yield return dt;
                dates.Add(dt);
                dt = func(dt);
            } while (dt <= to);
            return dates;
        }

        public static bool IsWeekend(this DateTime dt)
        {
            return (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday);
        }

        public static bool IsWeekday(this DateTime dt)
        {
            return !dt.IsWeekend();
        }

        public static DateTime ToWeek(this DateTime dt)
        {
            while (dt.DayOfWeek != DayOfWeek.Monday)
            {
                dt = dt.AddDays(-1);
            }
            return dt;
        }

        public static DateTime ToClosestBusinessDate(this DateTime dt, bool forward = false)
        {
            if (dt.IsWeekend())
            {
                dt = forward ? dt.ToNextBusinessDate() : dt.ToPreviousBusinessDate();
            }
            return dt;
        }

        public static DateTime ToNextBusinessDate(this DateTime dt)
        {
            if (dt == DateTime.MaxValue || dt == DateTime.MinValue) throw new ArgumentOutOfRangeException(string.Format("Invalid asymptotic date: {0}.", dt));
            DateTime nextDate = default(DateTime);
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    nextDate = dt.AddDays(+2);
                    break;
                case DayOfWeek.Friday:
                    nextDate = dt.AddDays(+3);
                    break;
                default:
                    nextDate = dt.AddDays(+1);
                    break;
            }
            return nextDate;
        }

        public static DateTime ToPreviousBusinessDate(this DateTime dt)
        {
            if (dt == DateTime.MaxValue || dt == DateTime.MinValue) throw new ArgumentOutOfRangeException(string.Format("Invalid asymptotic date: {0}.", dt));
            DateTime previousDate = default(DateTime);
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    previousDate = dt.AddDays(-2);
                    break;
                case DayOfWeek.Monday:
                    previousDate = dt.AddDays(-3);
                    break;
                default:
                    previousDate = dt.AddDays(-1);
                    break;
            }
            return previousDate;
        }

        public static DateTime AddBusinessDays(this DateTime dt, int days)
        {
            if (dt == DateTime.MaxValue || dt == DateTime.MinValue) throw new ArgumentOutOfRangeException(string.Format("Invalid asymptotic date: {0}.", dt));
            while (days != 0)
            {
                if (days > 0)
                {
                    dt = ToNextBusinessDate(dt);
                    --days;
                }
                else
                {
                    dt = ToPreviousBusinessDate(dt);
                    ++days;
                }
            }
            return dt;
        }

        public static DateTime Max(DateTime dt1, DateTime dt2) { return dt1 > dt2 ? dt1 : dt2; }

        public static DateTime Min(DateTime dt1, DateTime dt2) { return dt1 < dt2 ? dt1 : dt2; }

        public static string ConvertSecondsToText(int seconds)
        {
            StringBuilder output = new StringBuilder();
            int minutes = seconds / 60;
            if (minutes >= 1)
            {
                seconds = seconds % 60;
            }
            int hours = minutes / 60;
            if (hours >= 1)
            {
                minutes = minutes % 60;
            }
            if (hours >= 1)
            {
                output.Append(string.Format("{0} hours", hours));
            }
            if (minutes >= 1)
            {
                if (output.Length > 0)
                {
                    output.Append(", ");
                }
                output.Append(string.Format("{0} minutes", minutes));
            }
            if (seconds >= 1)
            {
                if (output.Length > 0)
                {
                    output.Append(", ");
                }
                output.Append(string.Format("{0} seconds", seconds));
            }
            if (output.Length == 0)
            {
                output.Append("zero seconds");
            }
            return output.ToString();
        }
    }
}
