using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI enemyKills;
    [SerializeField] int enemyKillNumberToWin = 100;
    
    [NonSerialized] public int EnemyKillCount = 0;

    void Start()
    {
        winText.enabled = false;
    }

    void Update()
    {
        EnemyKillsUpdate();
        WinConditionMet();
    }

    void EnemyKillsUpdate()
    {
        enemyKills.text = "Enemy kills: " + EnemyKillCount + "/" + enemyKillNumberToWin;
    }

    void WinConditionMet()
    {
        if (EnemyKillCount >= enemyKillNumberToWin)
        {
            winText.enabled = true;
            Time.timeScale = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(1); //first scene w/o introduction
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(nextScene);
            Time.timeScale = 1;
        }
    }
}
