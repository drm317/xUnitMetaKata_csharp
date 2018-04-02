namespace RockPaperScissors
{
    public class Player
    {
        public static Player Paper;
        public static Player Scissors;
        public static Player Rock;
        private Player _wins;
        private string _name;

        static Player()
        {
            Scissors = new Player("Scissors");
            Rock = new Player("Rock");
            Paper = new Player("Paper");
            Rock._wins = Scissors;
            Paper._wins = Rock;
            Scissors._wins = Paper;
        }

        public Player(string name)
        {
            _name = name;
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