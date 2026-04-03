
public class MoveLeftCommand : ICommand
{
    private readonly CommandPlayer player;

    public MoveLeftCommand(CommandPlayer player) // This is a constructor
    {
        this.player = player;
    }
    public void Execute()
    {
        // Implementation for executing the move left command
        player.MoveLeft();
    }

    public void Undo()
    {
        // Implementation for undoing the move left command
        player.MoveRight(); // Assuming there's a MoveRight method to undo the move left
    }

}
