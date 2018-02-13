namespace Tic_Tac_Toe
{
    public class WinGoal : Goal
    {
        private bool[,] moves;
        private int x;
        private int y;

        public bool GoalReached()
        {
            return CheckHorizontal(moves, x) || CheckVertical(moves, y)
                || CheckDiagLeft(moves) || CheckDiagRight(moves);
        }

        public void UpdateCurrentMove(bool[,] moves, int x, int y)
        {
            this.moves = moves;
            this.x = x;
            this.y = y;
        }

        private bool CheckHorizontal(bool[,] moves, int x)
        {
            for (int i = 0; i < MainForm.Y; i++)
            {
                if (!moves[x, i])
                    return false;
            }

            return true;
        }

        private bool CheckVertical(bool[,] moves, int y)
        {
            for (int i = 0; i < MainForm.X; i++)
            {
                if (!moves[i, y])
                    return false;
            }

            return true;
        }

        private bool CheckDiagLeft(bool[,] moves)
        {
            for (int i = 0; i < MainForm.X; i++)
            {
                if (!moves[i, i])
                    return false;
            }

            return true;
        }

        private bool CheckDiagRight(bool[,] moves)
        {
            for (int i = 0; i < MainForm.X; i++)
            {
                if (!moves[i, (MainForm.X - 1) - i])
                    return false;
            }

            return true;
        }
    }
}
