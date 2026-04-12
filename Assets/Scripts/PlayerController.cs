using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 20f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Rigidbody2D RB2D;
    private float input;
    private LE9_Input inputActions; // Reason for generating input script is so you can actually see what its doing in the inspector, and to make it easier to change the input scheme if you want to. Also, it makes it easier to add new input actions in the future if you want to expand the game.
    public int score;

    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        inputActions = new();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove; // OnMove didn't exist untill I generated it with the [Ctrl + .] shortcut
        inputActions.Player.Move.canceled += OnMove;
   }
    private void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<float>(); 
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Disable();
    }
    private void Start()
    {
        SetScore(0);
        Debug.Log("Score has been set to 0");
    }

    private void Update()
    {
        // input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        RB2D.AddForce(new Vector2(input * moveForce, 0f));

        if (Mathf.Abs(RB2D.linearVelocity.x) > maxSpeed)
        {
            RB2D.linearVelocity = new Vector2(Mathf.Sign(RB2D.linearVelocity.x) * maxSpeed, RB2D.linearVelocity.y);
        }
    }

    private void SetScore(int newScore)
    {
        this.score = newScore;
        scoreText.text = $"Score: {newScore}";
    }

    public void IncrementScore(int incrementor)
    {
        SetScore(this.score + incrementor);
    }
}