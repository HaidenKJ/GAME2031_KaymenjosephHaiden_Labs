
public class MoveRightCommand : ICommand
{
    private readonly CommandPlayer player;

    public MoveRightCommand(CommandPlayer player) // This is a constructor
    {
        this.player = player;
    }
    public void Execute()
    {
        // Implementation for executing the move left command
        player.MoveRight();
    }

    public void Undo()
    {
        // Implementation for undoing the move left command
        player.MoveLeft(); // Assuming there's a MoveLeft method to undo the move right
    }

}
