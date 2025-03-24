using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 5;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesNumber;
    [SerializeField] TextMeshProUGUI scoreNumber;
    void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
        
    }

    void Start()
    {
        livesNumber.text = playerLives.ToString();
        scoreNumber.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            // ResetGameSession();
            FindObjectOfType<ScenePersist>().ResetScenePersist();
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScreen"); //
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreNumber.text = score.ToString();

    }

    // void ResetGameSession()
    // {   
    //     FindObjectOfType<ScenePersist>().ResetScenePersist();
    //     SceneManager.LoadScene(0);
    //     Destroy(gameObject);
    // }

    void TakeLife()
    {
        playerLives --;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesNumber.text = playerLives.ToString();
    }
}
