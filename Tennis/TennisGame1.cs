using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    class Player
    {
        private static string[] PointNames = new string[]{
            "Love",
            "Fifteen",
            "Thirty",
            "Forty"
        };

        public Player(string name)
        {
            Name = name;
        }
     
        public string Name { get; }
        private int _points;
     
        public int Points
        {
            get { return _points; }
        }

        public void WonPoint()
        {
            _points++;
        }

        public string GetScore()
        {
            return PointNames[_points];
        }
    }

    class TennisGame1 : ITennisGame
    {
        Player _player1;
        Player _player2;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if(_player1.Name==playerName)
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
            string score = "";

            if (_player1.Points == _player2.Points)
            {
                if (_player1.Points > 2)
                    score = "Deuce";
                else
                    score = _player1.GetScore() + "-All";
            }
            else if (_player1.Points >= 4 || _player2.Points >= 4)
            {
                var pointDifference = _player1.Points - _player2.Points;
                if (pointDifference == 1) score = "Advantage player1";
                else if (pointDifference == -1) score = "Advantage player2";
                else if (pointDifference >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                score = _player1.GetScore() + "-" + _player2.GetScore();
            }
            return score;
        }
    }
}

