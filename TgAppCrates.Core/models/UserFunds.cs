namespace TgAppCrates.Core.models;

public class UserFunds
{
    public UserFunds(Guid id, string tgId, ulong funds)
    {
        Id = id;
        TgId = tgId;
        Funds = funds;
    }

    public Guid Id { get; set; }
    public string TgId { get; set; }
    public ulong Funds { get; set; }

    public static UserFunds Create(Guid id, string tgId, ulong funds)
    {
        var userFund = new UserFunds(id, tgId, funds);
        return userFund;
    }
}