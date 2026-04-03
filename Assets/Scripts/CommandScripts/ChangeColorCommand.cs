using UnityEngine;

public class ChangeColorCommand : ICommand
{
    private readonly CommandPlayer player;
    private readonly Color newColor;
    private Color oldColor;

    public ChangeColorCommand(CommandPlayer player, Color newColor)
    {
        this.player = player;
        this.newColor = newColor;
    }

    public void Execute()
    {
        // Store the old color before changing it
        oldColor = player.CurrentColor; // Assuming there's a GetColor method to retrieve the current color
        player.ChangeColor(newColor); // Assuming there's a SetColor method to change the player's color
        Debug.Log($"Changed color to {newColor}");
    }

    public void Undo()
    {
        player.ChangeColor(oldColor); // Revert to the old color
        Debug.Log($"Reverted color to {oldColor}");
    }
}