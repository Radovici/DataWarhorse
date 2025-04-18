using Core.Interfaces.DataModels;

namespace DataModels.SecurityMaster;

public partial class Country : ICountry
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string? Region { get; private set; }

    public string? SubRegion { get; private set; }

    public int? CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    ICurrency? ICountry.Currency => (ICurrency?)this.Currency;
}