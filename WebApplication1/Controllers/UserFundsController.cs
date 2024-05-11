namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;
using TgAppCrates.Core.Abstractions;
using WebApplication1.Contracts;

[ApiController]
[Route("api/v1/funds")]
public class UserFundsController : ControllerBase
{
    private readonly IUserFundsRepository _userFundsRepository;

    public UserFundsController(IUserFundsRepository userFundsRepository)
    {
        _userFundsRepository = userFundsRepository;
    }

    [HttpGet("user-funds")]
    public ActionResult<ulong> GetCards([FromQuery] string tgId)
    {
        var funds = _userFundsRepository.GetUserFunds(tgId);
        var response = new UserFundsResponse(funds);
        return Ok(response);
    }

    [HttpPatch("add-funds-to-user")]
    public async Task<ActionResult> AddFundsToUser([FromQuery] string tgId, [FromQuery] ulong fundsAmount)
    {
        await _userFundsRepository.AddFundsToUser(tgId, fundsAmount);
        return Created();
    }

    [HttpPatch("remove-funds-to-user")]
    public async Task<ActionResult<bool>> RemoveFundsFromUser([FromQuery] string tgId, [FromQuery] ulong fundsAmount)
    {
        var response =await _userFundsRepository.RemoveFundsFromUser(tgId, fundsAmount);
        return Ok(response);
    }
}