using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void SelectStage()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void Retry()
    {
        PlayerPrefs.SetInt("currentStage", int.Parse(this.name));
        SceneManager.LoadScene("MainScene");
    }
}