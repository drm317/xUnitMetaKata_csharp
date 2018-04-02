namespace RockPaperScissors
{
    public class Round
    {
        public int Play(Player player1, Player player2)
        {
            if (player1 == null || player2 == null)
            {
                throw new InvalidMoveException();
            }

            return player1.PlayHands(player2);
        }
    }
}