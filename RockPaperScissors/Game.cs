namespace RockPaperScissors
{
    public class Game
    {
        private readonly IGameListener _listener;
        private int _player1Score;
        private int _player2Score;

        public Game(IGameListener listener)
        {
            _listener = listener;
        }

        public void PlayRound(Player player1, Player player2)
        {
            var result = new Round().Play(player1, player2);
            switch (result)
            {
                case 1:
                    _player1Score++;
                    break;
                case 2:
                    _player2Score++;
                    break;
            }

            if (_player1Score == 2) _listener.GameOver(1);

            if (_player2Score == 2) _listener.GameOver(2);
        }
    }
}