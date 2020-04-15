namespace Tennis
{
    public class Player
    {
        private static readonly string[] PointNames =
        {
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
            if (Points == opponent.Points) return Points > 2 ? "Deuce" : GetScore() + "-All";

            if (Points < 4 && opponent.Points < 4) return $"{GetScore()}-{opponent.GetScore()}";

            var pointDifference = Points - opponent.Points;
            return pointDifference switch
            {
                1 => $"Advantage {Name}",
                -1 => $"Advantage {opponent.Name}",
                _ => pointDifference >= 2 ? $"Win for {Name}" : $"Win for {opponent.Name}"
            };
        }
    }
}