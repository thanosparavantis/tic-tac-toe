
namespace Tic_Tac_Toe
{
    public class Player
    {
        public string Νame { get; private set; }

        public string Μark { get; private set; }

        public Color Color { get; private set; }

        public int Score { get; private set; }

        public bool IsComputer { get; private set; }

        public bool[,] Moves { get; private set; }

        private WinGoal winGoal;
        private DrawGoal drawGoal;
        private Random random;

        public Player(string name, string mark, Color color, bool isComputer = false)
        {
            Νame = name;
            Μark = mark;
            Color = color;
            IsComputer = isComputer;
            Moves = new bool[5, 5];
            winGoal = new WinGoal();
            drawGoal = new DrawGoal();

            random = new Random();
        }
        
        public Button SelectButton(Player otherPlayer, Button[,] buttons)
        {
            int randX, randY;

            do
            {
                randX = random.Next(0, MainForm.X);
                randY = random.Next(0, MainForm.Y);
            } while (otherPlayer.Moves[randX, randY] || Moves[randX, randY]);

            return buttons[randX, randY];
        }

        public MoveState MakeMove(Button button, int x, int y)
        {
            button.ForeColor = Color;
            button.Text = Μark;

            Moves[x, y] = true;

            MainForm.MatchMoves++;

            winGoal.UpdateCurrentMove(Moves, x, y);

            if (winGoal.GoalReached())
                return MoveState.Win;
            else if (drawGoal.GoalReached())
                return MoveState.Draw;
            else
                return MoveState.Continue;
        }
        
        public void AddWin()
        {
            Score++;
        }

        public void ResetMoves()
        {
            Moves = new bool[MainForm.X, MainForm.Y];
        }

        public override string ToString()
        {
            return Νame;
        }
    }
}
