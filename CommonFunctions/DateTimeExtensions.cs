using System.Text;

namespace CommonFunctions
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<DateOnly> To(this DateOnly from, DateOnly to, bool includeNonBusinessDays)
        {
            if (from > to)
                throw new ArgumentException(string.Format("Invalid date range: from date ({0}) is greater than the to date {1}.",
                    from.ToShortDateString(), to.ToShortDateString()));
            Func<DateOnly, DateOnly> func = lmb => includeNonBusinessDays ? lmb.AddDays(1) : lmb.AddBusinessDays(1);
            List<DateOnly> dates = new List<DateOnly>();
            DateOnly dt = from;
            do
            {
                //yield return dt;
                dates.Add(dt);
                dt = func(dt);
            } while (dt <= to);
            return dates;
        }

        public static bool IsWeekend(this DateOnly dt)
        {
            return (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday);
        }

        public static bool IsWeekday(this DateOnly dt)
        {
            return !dt.IsWeekend();
        }

        public static DateOnly ToWeek(this DateOnly dt)
        {
            while (dt.DayOfWeek != DayOfWeek.Monday)
            {
                dt = dt.AddDays(-1);
            }
            return dt;
        }

        public static DateOnly ToClosestBusinessDate(this DateOnly dt, bool forward = false)
        {
            if (dt.IsWeekend())
            {
                dt = forward ? dt.ToNextBusinessDate() : dt.ToPreviousBusinessDate();
            }
            return dt;
        }

        public static DateOnly ToNextBusinessDate(this DateOnly dt)
        {
            if (dt == DateOnly.MaxValue || dt == DateOnly.MinValue) throw new ArgumentOutOfRangeException(string.Format("Invalid asymptotic date: {0}.", dt));
            DateOnly nextDate = default(DateOnly);
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

        public static DateOnly ToPreviousBusinessDate(this DateOnly dt)
        {
            if (dt == DateOnly.MaxValue || dt == DateOnly.MinValue) throw new ArgumentOutOfRangeException(string.Format("Invalid asymptotic date: {0}.", dt));
            DateOnly previousDate = default(DateOnly);
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

        public static DateOnly AddBusinessDays(this DateOnly dt, int days)
        {
            if (dt == DateOnly.MaxValue || dt == DateOnly.MinValue) throw new ArgumentOutOfRangeException(string.Format("Invalid asymptotic date: {0}.", dt));
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

        public static DateOnly Max(DateOnly dt1, DateOnly dt2) { return dt1 > dt2 ? dt1 : dt2; }

        public static DateOnly Min(DateOnly dt1, DateOnly dt2) { return dt1 < dt2 ? dt1 : dt2; }

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
