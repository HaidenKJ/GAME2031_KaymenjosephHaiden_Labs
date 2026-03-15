using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 20f;
    [SerializeField] private float maxSpeed = 5f;

    private Rigidbody2D RB2D;
    private float input;

    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        RB2D.AddForce(new Vector2(input * moveForce, 0f));

        if (Mathf.Abs(RB2D.linearVelocity.x) > maxSpeed)
        {
            RB2D.linearVelocity = new Vector2(
                Mathf.Sign(RB2D.linearVelocity.x) * maxSpeed,
                RB2D.linearVelocity.y
            );
        }
    }
}