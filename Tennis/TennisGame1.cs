using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Player _player1;
        private readonly Player _player2;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (_player1.Name == playerName)
            {
                _player1.WonPoint();
            }
            else
            {
                _player2.WonPoint();
            }
        }

        public string GetScore()
        {
            return _player1.GetComparativeScore(_player2);
        }
    }
}