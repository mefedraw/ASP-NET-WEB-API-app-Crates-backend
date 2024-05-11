namespace TgAppCrates.Core.models;

public class TradeCard
{
    public TradeCard(Guid id, short type, string ownerTgId, ulong price)
    {
        Id = id;
        Type = type;
        OwnerTgId = ownerTgId;
        Price = price;
    }

    public Guid Id { get; set; }
    public short Type { get; set; }
    public string OwnerTgId { get; set; }
    public ulong Price { get; set; }
}