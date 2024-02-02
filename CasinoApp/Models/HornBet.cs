using NuGet.Protocol.Core.Types;

namespace CasinoApp.Models
{
    public class HornBet
    {
        public int DiceNumber { get; set; }
        public int RandomBet { get; set; }
        public int UserAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
