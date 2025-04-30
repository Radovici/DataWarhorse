namespace CommonFunctions
{
    public static class DoubleExtensions
    {
        public static bool IsZero(this double value)
        {
            return (Math.Abs(value) < 0.00001); // Double.Epsilon);
        }

        public static DateOnly Min(DateOnly dt1, DateOnly dt2) { return dt1 < dt2 ? dt1 : dt2; }
    }
}
