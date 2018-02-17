namespace Tic_Tac_Toe
{
    public interface Goal
    {
        // This interface is used to create Goals that can be achieved depending on certain critera.
        // The GoalReached() method returns a boolean value that determines if the goal has been reached.

        bool GoalReached();
    }
}
