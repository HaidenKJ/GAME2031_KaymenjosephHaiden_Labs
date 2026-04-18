using System.Collections;
using TMPro;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fallingObjectPrefab;
    [SerializeField] private float ySpawnPosition;
    [SerializeField] private Vector2 xSpawnRange;

    [SerializeField] public int lives = 5;
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] private TextMeshProUGUI LivesText;

    private float quitTimer = 3f;
    private bool gameOver = false;

    void Start()
    {
        GameOverText.gameObject.SetActive(false);
        UpdateLivesUI();
        StartCoroutine(SpawnFallingObject());
    }

    void Update()
    {
        if (!gameOver && lives <= 0)
        {
            TriggerGameOver();
        }

        if (gameOver)
        {
            quitTimer -= Time.unscaledDeltaTime;

            if (quitTimer <= 0f)
            {
                Application.Quit();
            }
        }
    }

    private void TriggerGameOver()
    {
        gameOver = true;

        Debug.Log("Game Over!");
        GameOverText.gameObject.SetActive(true);

        StopAllCoroutines();
        Time.timeScale = 0f;
    }

    private IEnumerator SpawnFallingObject()
    {
        while (!gameOver)
        {
            GameObject go = Instantiate(
                fallingObjectPrefab,
                GenSpawnPosition(),
                Quaternion.identity
            );

            go.GetComponent<FallingObject>().Initialize();

            yield return new WaitForSeconds(1.0f);
        }
    }

    private Vector3 GenSpawnPosition()
    {
        return new Vector3(
            Random.Range(xSpawnRange.x, xSpawnRange.y),
            ySpawnPosition,
            0.0f
        );
    }

    private void OnEnable()
    {
        FallingObject.OnFallingObjectDestroyed += DecreaseLives;
    }

    private void OnDisable()
    {
        FallingObject.OnFallingObjectDestroyed -= DecreaseLives;
    }

    void DecreaseLives()
    {
        if (gameOver) return;

        lives--;
        UpdateLivesUI();

        Debug.Log("Lives left: " + lives);
    }

    void UpdateLivesUI()
    {
        Debug.Log("Updating UI: " + lives);
        LivesText.text = $"HP: {lives}";
    }
}