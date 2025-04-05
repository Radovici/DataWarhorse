using DataModels.Interfaces;
using DataModels.SecurityMaster;

namespace DataModels.MarketData;

public partial class Exchange : IExchange
{
    public int Id { get; private set; }

    public int? CountryId { get; private set; }

    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public bool Alternative { get; private set; }

    public string? FigiCode { get; private set; }

    public string? ExchangeCode { get; private set; }

    public string? CountryCode { get; private set; } // TODO: is this redundant against CountryId?

    public Country? Country { get; set; }

    ICountry? IExchange.Country => Country;
}
