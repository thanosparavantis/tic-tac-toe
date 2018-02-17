namespace Tic_Tac_Toe
{
    // Delegate declaration

    // When you instantiate a delegate, you can associate its instance
    // with any method with a compatible signature and return type.

    // Any method from any accessible class or struct that matches
    // the delegate type can be assigned to the delegate.

    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/

    public delegate void GameCreationHandler(Player player1, Player player2);
}
