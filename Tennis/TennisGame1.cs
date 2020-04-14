using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    class Player
    {
        private static readonly string[] PointNames = new string[]{
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

        private string GetScore()
        {
            return PointNames[_points];
        }

        public string GetComparativeScore(Player opponent)
        {
            var score="";
            if (Points == opponent.Points)
            {
                return Points > 2 ? 
                    score = "Deuce"
                :
                    score = GetScore() + "-All";
            }
            
            if (Points >= 4 || opponent.Points >= 4)
            {
                var pointDifference = Points - opponent.Points;
                if (pointDifference == 1) score = "Advantage player1";
                else if (pointDifference == -1) score = "Advantage player2";
                else if (pointDifference >= 2) score = "Win for player1";
                else score = "Win for player2";

                return score;
            }
            
            return GetScore() + "-" + opponent.GetScore();
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
            return _player1.GetComparativeScore(_player2);
        }
    }
}

