using Core.Interfaces.DataModels;
using Core.Interfaces.Services;

namespace UnifiedDataModels.Models.PositionData
{
    public class Trade : ITrade
    {
        private IQueryableTrade _trade;
        private ISecurityService _securityService;

        public Trade(IQueryableTrade trade, ISecurityService securityService)
        {
            _trade = trade;
            _securityService = securityService;
        }

        public int TradeId => _trade.TradeId;

        public ISecurity Security => _securityService.GetSecurity(this._trade.SecurityId)!;

        public IFund Fund => (IFund)_trade.Fund;

        public DateTime TradeDate => this._trade.TradeDate;

        public double Quantity => this._trade.Quantity;

        public double Price => this._trade.Price;

        public double Commission => this._trade.Commission;
    }
}
