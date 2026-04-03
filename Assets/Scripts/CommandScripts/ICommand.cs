public interface ICommand  // Stands for Interface Command
{
    void Execute();  // Method to execute the command
    void Undo();     // Method to undo the command
}
