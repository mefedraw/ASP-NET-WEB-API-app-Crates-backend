namespace TgAppCrates.Core.models;

public class TradeCard
{
    public TradeCard(Guid id, short type, string cardName, string url, string ownerTgId, ulong price)
    {
        Id = id;
        Type = type;
        CardName = cardName;
        Url = url;
        OwnerTgId = ownerTgId;
        Price = price;
    }

    public Guid Id { get; set; }
    public short Type { get; set; }
    public string CardName { get; set; }
    public string Url { get; set; }
    public string OwnerTgId { get; set; }
    public ulong Price { get; set; }
}