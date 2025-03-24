using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelNumber)
    {
        string levelName = "Level " + levelNumber;
        SceneManager.LoadScene(levelName);
    }
}
