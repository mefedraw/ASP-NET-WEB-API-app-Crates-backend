namespace TgAppCrates.Core.models;

public class Card
{
    public Card(Guid id, string tgId, short type, int count)
    {
        Id = id;
        TgId = tgId;
        Type = type;
        Count = count;
    }

    public Guid Id { get; set; }
    public string TgId { get; set; }
    public short Type { get; set; }

    public int Count { get; set; }

    public static Card Create(Guid id, string tgId, short type, int count)
    {
        var card = new Card(id, tgId, type, count);
        return card;
    }
}