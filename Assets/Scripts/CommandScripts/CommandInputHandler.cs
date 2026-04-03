using UnityEngine;

public class CommandInputHandler : MonoBehaviour
{
    [SerializeField] private CommandPlayer player;
    private CommandHistory history;

    private void Awake()
    {
        history = new CommandHistory();
    }

    private void Update()
    {
        if (player == null) return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            history.ExecuteCommand(new MoveLeftCommand(player));
            Debug.Log("Player Moved Left");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            history.ExecuteCommand(new MoveRightCommand(player));
            Debug.Log("Player Moved Right");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            var colorCmd = new ChangeColorCommand(player, Random.ColorHSV());
            colorCmd.Execute();
            Debug.Log("Color Changed");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            history.Undo();
            Debug.Log("Undo Command");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            history.Redo();
            Debug.Log("Redo Command");
        }
    }
}