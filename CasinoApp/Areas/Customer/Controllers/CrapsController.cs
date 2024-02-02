using CasinoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CasinoApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CrapsController : Controller
    {
        public IActionResult Index()
        {
            HornBet? game = GenerateNewGame();
            return View(game);
        }

        [HttpPost]
        public IActionResult CheckAnswer(HornBet hornBet)
        {
            hornBet.IsCorrect = hornBet.UserAnswer == CalculateHorBetPayout(hornBet.DiceNumber, hornBet.RandomBet);

            if (hornBet.IsCorrect)
            {
                hornBet = GenerateNewGame();
            }

            return View("Index", hornBet);
        }

        private HornBet GenerateNewGame()
        {
            HornBet hornGame = new HornBet
            {
                DiceNumber = GetRandomDiceNumber(),
                RandomBet = GetRandomBet(),
                UserAnswer = 0,
                IsCorrect = false
            };

            return hornGame;
        }   
        // Random Dice Number
        private int GetRandomDiceNumber()
        {
            var random = new Random();
            var diceNumbers = new[] { 2, 3, 11, 12 };
            return diceNumbers[random.Next(diceNumbers.Length)];
        }

        private int GetRandomBet()
        {
            var random = new Random();
            var bet = random.Next(1, 50) * 4;
            return bet;
        }

        private int CalculateHorBetPayout(int diceNumber, int bet)
        {
            if (diceNumber == 3 || diceNumber == 11)
                return bet * 3;
            else
                return (bet * 7) - bet / 4;
        }
    }

    

    
}
