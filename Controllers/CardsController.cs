using Microsoft.AspNetCore.Mvc;
using TgAppCrates.Core.Abstractions;
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

        [HttpGet()]
        public async Task<ActionResult<List<GetAllCardsResponse>>> GetCards([FromQuery]string TgId)
        {
            var cards = await _cardRepository.GetCards(TgId);

            var response = cards.Select(c => new GetAllCardsResponse(c.Id, c.TgId, c.Type, c.Count));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> AddCardToUser([FromQuery]string tgId,[FromQuery] short type)
        {
            await _cardRepository.AddCardToUser(tgId, type);
            return Created();
        }
    }
}