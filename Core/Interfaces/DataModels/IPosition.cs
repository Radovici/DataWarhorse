namespace Core.Interfaces.DataModels
{
    public interface IPosition
    {
        // Performance calculations
        double Pnl { get; }
        // Dates
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        // NOTE: start/end quantity and price? Do we really want the exposures, risk analytics, and assets? At least further interface that.
        // Exposure calculations
        double OpenMarketValue { get; } // NOTE: what's "Open" again (been a few years since revisiting this codebase)?
        double StartMarketValue { get; }
        double EndMarketValue { get; }
        double StartDeltaExposure { get; }
        double EndDeltaExposure { get; }
        double StartBetaExposure { get; }
        double EndBetaExposure { get; }
        // Risk calculations
        double StartValueAtRisk { get; }
        double EndValueAtRisk { get; }
        double StartDailyVolatility { get; }
        double EndDailyVolatility { get; }
        // Assets
        double StartAum { get; }
        double EndAum { get; }
        IEnumerable<IDailyPosition> DailyPositions { get; }
        IPosition? Parent { get; }
    }
}
