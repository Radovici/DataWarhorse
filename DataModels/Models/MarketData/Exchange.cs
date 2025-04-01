using DataModels.Interfaces;
using DataModels.SecurityMaster;

namespace DataModels.MarketData;

public partial class Exchange
{
    public int Id { get; private set; }

    private int? _countryId { get; set; }

    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public bool Alternative { get; private set; }

    public string? FigiCode { get; private set; }

    public string? ExchangeCode { get; private set; }

    public string? CountryCode { get; private set; } // TODO: is this redundant against CountryId?

    private Country? _country { get; set; }

    public ICountry? Country => Country;
}
