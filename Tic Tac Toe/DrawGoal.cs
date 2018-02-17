namespace Tic_Tac_Toe
{
    class DrawGoal : Goal
    {
        // This class performs a check every time the player makes a move on the board.
        // It will determine if the match can end as a draw.

        public bool GoalReached()
        {
            // Check if the number of moves for this match are equal to the size of the board.
            // Then we can safely determine that there are no moves left.
            return MainForm.MatchMoves == MainForm.X * MainForm.Y;
        }
    }
}
