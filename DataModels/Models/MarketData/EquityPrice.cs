﻿using Core.Interfaces.DataModels;

namespace DataModels.MarketData;

public partial class EquityPrice : IPrice
{
    public DateOnly Date { get; private set; }

    public int SecurityId { get; private set; }

    internal int? SourceId { get; private set; } // TODO: shouldn't be exposed

    public double StartPrice { get; private set; }

    public double EndPrice { get; private set; }

    public double Low { get; private set; }

    public double High { get; private set; }

    public double Volume { get; private set; }

    public DateTime CreateDateTime { get; private set; }

    public Source? Source { get; private set; }

    public ISecurity Security => throw new NotImplementedException();
}
