﻿using Core.Interfaces.DataModels;
using DataModels.MarketData;

namespace DataModels.SecurityMaster;

public partial class Security : ISecurity
{
    public static ISecurity Null = new Security() { Id = 0 };

    public int Id { get; private set; } // NOTE: don't love exposing IDs but gotta link it up somehow across data contexts, for now at least

    public int ExchangeId { get; private set; }

    public int? UnderlyingSecurityId { get; private set; }

    public int SecurityTypeId { get; private set; }

    public string Symbol { get; private set; } = null!;

    public DateTime CreateDateTime { get; private set; }

    public virtual SecurityType SecurityType { get; private set; } = null!;

    public virtual ISecurity? UnderlyingSecurity { get; }

    public ICollection<SecurityAttribute> SecurityAttributes { get; private set; } = new List<SecurityAttribute>();

    IEnumerable<ISecurityAttribute> ISecurity.SecurityAttributes => SecurityAttributes.Cast<ISecurityAttribute>();

    public Exchange Exchange { get; private set; } = null!; // maybe better just to expose normal casing and expose UDM mdoels publicly

    IExchange ISecurity.Exchange => Exchange;

    public ICountry Country { get; } = null!;

    public ICurrency Currency => Exchange.Country?.Currency ?? DataModels.SecurityMaster.Currency.Empty;

    public string? Display { get; } // TODO: should be name, i.e., nameable (instead of displayable)

    public double Multiplier => 1; // NOTE: this changes logically depending on security type (although may hae to be overridden and database driven)

    public string Name => Symbol;

    ISecurityType ISecurity.SecurityType => throw new NotImplementedException();

    public DateOnly StartDate => throw new NotImplementedException();

    public DateOnly EndDate => throw new NotImplementedException();
}
