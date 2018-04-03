namespace RockPaperScissors
{
    public class Player
    {
        public static Player Paper;
        public static Player Scissors;
        public static Player Rock;
        private Player _wins;
        internal string Hand;

        static Player()
        {
            Scissors = new Player {Hand = "Scissors"};
            Rock = new Player {Hand = "Rock"};
            Paper = new Player {Hand = "Paper"};
            Rock._wins = Scissors;
            Paper._wins = Rock;
            Scissors._wins = Paper;
        }

        public int PlayHands(Player player2)
        {
            if (player2 == this) return 0;
            return player2 == _wins ? 1 : 2;
        }

        public override string ToString()
        {
            return Hand;
        }
    }
}