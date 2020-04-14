using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    class Player
    {
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
    }

    class TennisGame1 : ITennisGame
    {
        private List<Player> _players = new List<Player>();

        private string[] PointNames = new string[]{
            "Love",
            "Fifteen",
            "Thirty",
            "Forty"
        };

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
                    score = PointNames[player1.Points] + "-All";
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
                score = PointNames[player1.Points] + "-" + PointNames[player2.Points];
            }
            return score;
        }
    }
}

