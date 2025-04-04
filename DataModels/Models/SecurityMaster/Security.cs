using DataModels.Interfaces;
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

    public ICollection<SecurityAttribute> _securityAttributes { get; private set; } = new List<SecurityAttribute>();

    public IEnumerable<ISecurityAttribute> SecurityAttributes => _securityAttributes.Cast<ISecurityAttribute>();

    public virtual SecurityType SecurityType { get; private set; } = null!;

    public virtual ISecurity? UnderlyingSecurity { get; }

    public string? Display { get; } // TODO: should be name, i.e., nameable (instead of displayable)

    public double Multiplier => 1; // NOTE: this changes logically depending on security type (although may hae to be overridden and database driven)

    public Exchange _exchange { get; private set; } = null!; // maybe better just to expose normal casing and expose UDM mdoels publicly

    public IExchange Exchange => _exchange;

    public ICountry Country { get; } = null!;

    public ICurrency Currency => Exchange.Country?.Currency ?? DataModels.SecurityMaster.Currency.Empty;

    public string Name => Symbol;
}
