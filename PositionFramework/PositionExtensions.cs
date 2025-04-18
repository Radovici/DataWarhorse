using Core.Interfaces.DataModels;

namespace PositionFramework
{
    public static class PositionExtensions
    {
        public static Portfolio GetPortfolio(this IPosition position)
        {
            IPosition? parent = position.Parent;
            if (parent != null)
            {
                parent = parent.GetPortfolio();
            }
            else
            {
                parent = position;
            }
            return (Portfolio)parent; // root parent should be a portfolio (or IPortfolio) by _our_ definition
        }
    }
}
