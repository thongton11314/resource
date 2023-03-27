using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CardGame.Service;
using CardGame.Properties;

namespace CardGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardGameController : ControllerBase
    {
        private readonly CardGameService _cardGameService;

        public CardGameController(CardGameService cardGameService)
        {
            _cardGameService = cardGameService;
        }

        [HttpGet("drawcard")]
        public IActionResult DrawCard()
        {
            var cardInfo = _cardGameService.DrawCard();
            return Ok(cardInfo);
        }

        [HttpPost("shuffle")]
        public IActionResult Shuffle()
        {
            var shuffleResult = _cardGameService.Shuffle();
            return Ok(shuffleResult);
        }

        [HttpPost("restart")]
        public IActionResult Restart()
        {
            var restartResult = _cardGameService.Restart();
            return Ok(restartResult);
        }

        [HttpGet("show")]
        public IActionResult ShowCards()
        {
            var cardsInfo = _cardGameService.ShowCards();
            return Ok(cardsInfo);
        }

        [HttpPost("putcard")]
        public IActionResult PutCard([FromBody] Card card)
        {
            var putCardResult = _cardGameService.PutCard(card);
            return Ok(putCardResult);
        }
    }
}