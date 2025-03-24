using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform pointBoss;
    [SerializeField] private int scoreSpawn = 50;

    private bool bossSpawned = false;

    private void Update()
    {
        if(!bossSpawned && ScoreManager.instance != null && ScoreManager.instance.CurrentScore >= scoreSpawn)
        {
            Spawner();
        }
    }

    void Spawner()
    {
        Instantiate(bossPrefab, pointBoss.position, pointBoss.rotation);
        bossSpawned = true;
    }
}
