using Microsoft.AspNetCore.Mvc;
using TgAppCrates.Core.Abstractions;
using WebApplication1.Contracts;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;

        public CardsController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CardsResponse>>> iGetCards([FromQuery]string TgId)
        {
            var cards = await _cardRepository.GetCards(TgId);

            var response = cards.Select(c => new CardsResponse(c.Id, c.TgId, c.Type, c.Count));
            return Ok(response);
        }
    }
}