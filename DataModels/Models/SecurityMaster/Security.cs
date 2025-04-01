using DataModels.Interfaces;

namespace DataModels.SecurityMaster;

public partial class Security : ISecurity
{
    public static ISecurity Null = new Security() { Id = 0 };

    public int Id { get; set; }

    public int ExchangeId { get; set; }

    public int? UnderlyingSecurityId { get; set; }

    public int SecurityTypeId { get; set; }

    public string Symbol { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public virtual ICollection<SecurityAttribute> SecurityAttributes { get; set; } = new List<SecurityAttribute>();

    public virtual SecurityType SecurityType { get; set; } = null!;

    public virtual ISecurity? UnderlyingSecurity { get; }

    public string? Display { get; } // TODO: should be name, i.e., nameable (instead of displayable)

    public double Multiplier => 1; // NOTE: this changes logically depending on security type (although may hae to be overridden and database driven)

    public IExchange? Exchange { get; }

    public ICountry Country { get; } = null!;

    public ICurrency? Currency => Exchange?.Country?.Currency;

    public string Name => Symbol;
}
