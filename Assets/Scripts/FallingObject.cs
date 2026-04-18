using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingObject : MonoBehaviour
{
    public static event System.Action OnFallingObjectDestroyed;
    [SerializeField] private Vector2Int pointRange;
    private int points;

    public void Initialize()
    {
        points = Random.Range(pointRange.x, pointRange.y);
        gameObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.gameObject.name);

        PlayerController playerController = collision.gameObject.GetComponentInParent<PlayerController>();
        
        if (playerController != null)
        {
            playerController.IncrementScore(points);
            Debug.Log("+" + points);
        }

        
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnFallingObjectDestroyed?.Invoke();
            Debug.Log("Falling object collided with ground, lives decreased by 1");
        }

        Destroy(gameObject);
    }
}