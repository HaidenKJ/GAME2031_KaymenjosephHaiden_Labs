using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
           Debug.Log("Backspace was pressed"); 
        }
    }
}


// 4) Implement Player Movement 
// Create a script that allows the player to move left and right. 
// Movement should behave like a platformer character moving along the ground. 

// The player should: 
// • Move left when the left arrow key is pressed 
// • Move right when the right arrow key is pressed 
// Movement can be implemented using: 
// • Rigidbody2D velocity, or forces applied to the Rigidbody2D 