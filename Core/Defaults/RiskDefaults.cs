namespace Core.Defaults
{
    public static class RiskDefaults
    {
        public static Func<DateTime> DefaultDate = () => DateTime.Today;
        public static readonly int DefaultBetaRange = 256;
        public static readonly string DefaultBetaIndex = "SPX";
        public static readonly int DefaultValueAtRiskRange = 512;
        public static readonly double DefaultValueAtRiskConfidence = 0.95;
        public static readonly string DefaultValueAtRiskType = "Historical";
        public static readonly int DefaultVolatilityRange = 256 / 12;
        public static readonly int DefaultVolumeRange = 30;
        public static readonly int DefaultSharpeRange = 256;
    }
}
