using Core.Interfaces.DataModels;

namespace DataModels.SecurityMaster;

public partial class Currency : ICurrency
{
    public static Currency Empty = new Currency { Code = string.Empty, Name = "Empty" };

    public int Id { get; private set; }

    public string Code { get; private set; } = null!;

    public string Name { get; private set; } = null!;
}
