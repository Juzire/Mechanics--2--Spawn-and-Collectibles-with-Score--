using UnityEngine;
using TMPro;

public class CircleMechanics : MonoBehaviour
{
    public TextMeshProUGUI scoreText;      
    public TextMeshProUGUI gameOverText;   
    public float moveSpeed = 2f;
    private int score = 0;                 
    private bool isGameOver = false;       

    void Start()
    {
        UpdateScoreText();
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isGameOver)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        else
        {
            MoveObjects(); 
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString(); 
     }

    void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);  
    }

    public void HandleCollision(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            score += 1;               
            UpdateScoreText();
            Destroy(collision.gameObject);  
        }
        else if (collision.CompareTag("Obstacle"))
        {
            GameOver();  
        }
    }

    void MoveObjects()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");

        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);  
        }

        foreach (GameObject collectible in collectibles)
        {
            collectible.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);  
        }
    }
}
