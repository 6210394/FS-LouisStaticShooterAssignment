using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    public string[] levels;
    public int currentLevel = 0;
    public int targetLevel = 1;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timeText;

    public bool inGame = false;

    public static GameManager instance { get; private set;}
    

    [SerializeField]
    public float score = 0;
    public float lives = 3;
    public float time = 0;

    private bool isLifeBeingRemoved = false;

    public void AddScore(float scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }
    public void RemoveLife()
    {
        if (isLifeBeingRemoved)
        {
            return;
        }

        isLifeBeingRemoved = true;

        Debug.Log("Life Lost");
        lives--;
        if (lives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (lives <= 0)
        {
            Debug.Log("Game Over");
            targetLevel = 4;
            lives = 3;
            score = 0;
            time = 0;
            SceneManager.LoadScene(levels[targetLevel]);
        }
    }

    public void StartGame()
    {
        inGame = true;
    }

    void Update()
    {
        isLifeBeingRemoved = false;
        //Instant Kill Debug
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(levels[targetLevel + 1]);
            targetLevel++;
        }

        if (inGame)
        {
            if(scoreText == null || livesText == null || timeText == null)
            {
                scoreText = GameObject.Find("ScoreNum").GetComponent<TextMeshProUGUI>();
                livesText = GameObject.Find("LivesNum").GetComponent<TextMeshProUGUI>();
                timeText = GameObject.Find("TimeNum").GetComponent<TextMeshProUGUI>();
            }

            time += Time.deltaTime;
            timeText.text = time.ToString("F2");
            livesText.text = lives.ToString();

            if (currentLevel != targetLevel)
            {
                scoreText.text = score.ToString();
                livesText.text = lives.ToString();
                timeText.text = time.ToString("F2");
                currentLevel = targetLevel;
            }
        }

        if((SceneManager.GetActiveScene().name == levels[1] || SceneManager.GetActiveScene().name == levels[2] || SceneManager.GetActiveScene().name == levels[3]) && inGame == false)
        {
            inGame = true;
        }

        if(SceneManager.GetActiveScene().name == "End" && inGame == true)
        {
            inGame = false;
            scoreText.text = score.ToString();
            livesText.text = (3 - lives).ToString();
            timeText.text = time.ToString("F2");
        }              
    }

    public void CheckCompletion()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1) //this is 1 because the check happens before the enemy despawns
        {
            SceneManager.LoadScene(levels[targetLevel + 1]);
            targetLevel++;
        }
        else
        {
            return;
        }
    }
    

}
