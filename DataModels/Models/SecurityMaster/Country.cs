using DataModels.Interfaces;

namespace DataModels.SecurityMaster;

public partial class Country : ICountry
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string? Region { get; private set; }

    public string? SubRegion { get; private set; }

    internal int? CurrencyId { get; private set; }

    internal Currency? _currency { get; private set; }

    public ICurrency? Currency => this._currency;
}