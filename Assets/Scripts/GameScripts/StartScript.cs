using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.currentLevel = 0;
        GameManager.instance.targetLevel = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.instance.levels[GameManager.instance.targetLevel]);
    }
}
