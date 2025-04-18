using DataModels.Interfaces;
using Services.Security;

namespace UnifiedDataModels.Models.PositionData
{
    public class Trade : ITrade
    {
        private DataModels.PositionData.Trade _trade;
        private SecurityService _securityService;

        public Trade(DataModels.PositionData.Trade trade, SecurityService securityService)
        {
            _trade = trade;
            _securityService = securityService;
        }

        public int TradeId => _trade.TradeId;

        public ISecurity Security => _securityService.GetSecurity(this._trade.SecurityId)!;

        public IFund Fund => this._trade.Fund;

        public DateTime TradeDate => this._trade.TradeDate;

        public double Quantity => this._trade.Quantity;

        public double Price => this._trade.Price;

        public double Commission => this._trade.Commission;
    }
}
