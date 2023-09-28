using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("UI Text's")]
    [SerializeField] TextMeshProUGUI currentHealthTextUI;
    [SerializeField] GameObject lossCondition;

    [Header("Player HP in current round")]
    [SerializeField] int playerHealth = 10;

    int currentHealth = 0;
    bool lose = false;

    void Awake()
    {
        currentHealth = playerHealth;
        lossCondition.SetActive(false);
        SetCurrentHealth();
    }

    void Update()
    {
        RetryButton();
    }

    void RetryButton()
    {
        if (lose)
        {
            if (Input.GetKey(KeyCode.R))
            {
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentScene);
                Time.timeScale = 1;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        UpdateCurrentHealth();
    }

    void UpdateCurrentHealth()
    {
        currentHealth--;

        SetCurrentHealth();

        if (currentHealth <= 0)
        {
            lose = true;
            lossCondition.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void SetCurrentHealth()
    {
        currentHealthTextUI.text = "HP: " + currentHealth;
    }
}
