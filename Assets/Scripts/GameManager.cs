using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    private int score = 0;

    private bool gameStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted) {
            
            StartSpawning();

            tapText.SetActive(false);

            gameStarted = true;
        }
    }

    private void StartSpawning() {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock() { 
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        score++;
        scoreText.text =score.ToString();
    }
}
