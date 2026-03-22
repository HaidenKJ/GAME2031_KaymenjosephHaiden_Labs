using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingObject : MonoBehaviour
{
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

        Destroy(gameObject);
    }
}