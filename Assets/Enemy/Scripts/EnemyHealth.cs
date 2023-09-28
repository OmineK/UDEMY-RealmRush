using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyHealth : MonoBehaviour
{
    [Header("Hit calculator")]
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;

    Enemy enemy;
    WinCondition winCondition;

    void OnEnable()
    {
        winCondition = FindObjectOfType<WinCondition>();
        enemy = GetComponent<Enemy>();
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        HitProcess();
    }

    void HitProcess()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            winCondition.EnemyKillCount++;
            enemy.RewardGold();
            maxHitPoints += difficultyRamp;
            this.gameObject.SetActive(false);
        }
    }
}
