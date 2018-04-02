namespace RockPaperScissors
{
    public class Player
    {
        public static Player Paper;
        public static Player Scissors;
        public static Player Rock;
        private Player _wins;

        static Player()
        {
            Scissors = new Player();
            Rock = new Player();
            Paper = new Player();
            Rock._wins = Scissors;
            Paper._wins = Rock;
            Scissors._wins = Paper;
        }

        public int PlayHands(Player player2)
        {
            if (player2 == _wins)
            {
                return 1;
            }
            if (player2 == this)
            {
                return 0;
            }

            return 2;
        }
    }
}