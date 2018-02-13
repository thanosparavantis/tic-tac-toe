namespace Tic_Tac_Toe
{
    class DrawGoal : Goal
    {
        public bool GoalReached()
        {
            return MainForm.MatchMoves == MainForm.X * MainForm.Y;
        }
    }
}
