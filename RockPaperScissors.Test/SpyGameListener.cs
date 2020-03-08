namespace RockPaperScissors.Test
{
    public class SpyGameListener : IGameListener
    {
        public int Winner { get; private set; }

        public void GameOver(int winner)
        {
            Winner = winner;
        }
    }
}