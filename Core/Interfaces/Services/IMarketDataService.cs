﻿using Core.Interfaces.DataModels;

namespace Core.Interfaces.Services
{
    public interface IMarketDataService
    {
        double? GetPrice(ISecurity security, DateTime date);
    }

}
