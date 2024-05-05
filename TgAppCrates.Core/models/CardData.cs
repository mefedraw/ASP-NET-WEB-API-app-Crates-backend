namespace TgAppCrates.Core.models;

public class CardData
{
    public CardData(Guid id, short type, string cardName, string url)
    {
        Id = id;
        Type = type;
        CardName = cardName;
        Url = url;
    }

    public Guid Id { get; set; }
    public short Type { get; set; }

    public string CardName { get; set; }

    public string Url { get; set; }

    public static CardData Create(Guid id,  short type, string cardName, string url)
    {
        var card = new CardData(id, type, cardName, url);
        return card;
    }
}