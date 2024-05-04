using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void changeToGameOverScene()
    {
        SceneManager.LoadSceneAsync("GameOver");
    }

    public static void changeToGameScene()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public static void changeToStartScene()
    {
        SceneManager.LoadSceneAsync("Start");
    }
}
