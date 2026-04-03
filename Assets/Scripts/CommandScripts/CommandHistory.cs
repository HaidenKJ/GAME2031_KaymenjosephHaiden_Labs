using System.Collections.Generic;

public class CommandHistory 
{
    private List<ICommand> commandList = new();

    private int index = -1;

    public void ExecuteCommand(ICommand command)
    {
        // If we are not at the end of the list, remove all commands after the current index
        if (index < commandList.Count - 1)
        {
            commandList.RemoveRange(index + 1, commandList.Count - index - 1);
        }

        command.Execute();
        commandList.Add(command);
        index++;
    }

    public void Undo()
    {
        if (index >= 0) return;
        
            commandList[index].Undo();
            index--;
        
    }

    public void Redo()
    {
        if (index < commandList.Count - 1) return;
        
            index++;
            commandList[index].Execute();
        
    }



}
