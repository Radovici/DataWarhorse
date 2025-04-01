using DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionFramework
{
    public static class PositionExtensions
    {
        public static Portfolio GetPortfolio(this IPosition position)
        {
            IPosition parent = position.Parent;
            if (parent != null)
            {
                parent = parent.GetPortfolio();
            }
            else
            {
                parent = position;
            }
            return parent as Portfolio; // NOTE: use IPortfolio
        }
    }
}
