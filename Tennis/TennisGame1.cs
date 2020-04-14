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
        private List<Player> _players = new List<Player>();

        public TennisGame1(string player1Name, string player2Name)
        {
            _players.Add(new Player(player1Name));
            _players.Add(new Player(player2Name));
        }

        public void WonPoint(string playerName)
        {
            _players.First(p => p.Name == playerName).WonPoint();
        }

        public string GetScore()
        {
            string score = "";
            var player1 = _players[0];
            var player2 = _players[1];

            if (player1.Points == player2.Points)
            {
                if (player1.Points > 2)
                    score = "Deuce";
                else
                    score = player1.GetScore() + "-All";
            }
            else if (player1.Points >= 4 || player2.Points >= 4)
            {
                var pointDifference = player1.Points - player2.Points;
                if (pointDifference == 1) score = "Advantage player1";
                else if (pointDifference == -1) score = "Advantage player2";
                else if (pointDifference >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                score = player1.GetScore() + "-" + player2.GetScore();
            }
            return score;
        }
    }
}

