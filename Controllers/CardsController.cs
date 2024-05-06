using Microsoft.AspNetCore.Mvc;
using TgAppCrates.Core.Abstractions;
using TgAppCrates.Core.models;
using WebApplication1.Contracts;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/cards")]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;

        public CardsController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet("all-user-cards")] 
        public async Task<ActionResult<List<GetAllCardsResponse>>> GetCards([FromQuery] string TgId)
        {
            var cards = await _cardRepository.GetCards(TgId);
            Dictionary<int, Tuple<string, string>> tempUserCardDataDict = new Dictionary<int, Tuple<string, string>>();
            foreach (var c in cards)
            {
                var tempCardData = _cardRepository.GetCardData(c.Type);
                tempUserCardDataDict.Add(c.Type, Tuple.Create(tempCardData.CardName, tempCardData.Url));
            }

            var response = cards.Select(c =>
                new GetAllCardsResponse(c.Id, c.TgId, c.Type, c.Count, tempUserCardDataDict[c.Type].Item1,
                    tempUserCardDataDict[c.Type].Item2));
            return Ok(response);
        }

        [HttpPost("add-card-to-user")]
        public async Task<ActionResult> AddCardToUser([FromQuery] string tgId, [FromQuery] short type)
        {
            await _cardRepository.AddCardToUserAsync(tgId, type);
            return Created();
        }

        [HttpPost("add-card-data")]
        public async Task<ActionResult> AddCardData([FromQuery] short type,
            [FromQuery] string cardName, [FromQuery] string url)
        {
            await _cardRepository.AddCardData(type, cardName, url);
            return Created();
        }

        [HttpGet("random-card")]
        public async Task<ActionResult<GetRandomCardResponse>> GetRandomCard([FromQuery] string tg_id)
        {
            var cardData = await _cardRepository.GetRandomCardAsync(tg_id);
            var response = new GetRandomCardResponse(cardData.Type, cardData.CardName, cardData.Url);
            return Ok(response);
        }
    }
}