using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private float heightRange;
    [SerializeField] private GameObject obstaculeObj;
    [SerializeField] private float spawnPosition;
    private float cool_down;

    void Start()
    {
        cool_down = spawnInterval;
    }

    void Update()
    {
        cool_down -= Time.deltaTime;

        if (cool_down <= 0)
        {
            SpawnObstacule();
            cool_down = spawnInterval;
        }
    }

    void SpawnObstacule()
    {
        float yPos = Random.Range(-heightRange, heightRange);
        Vector3 spawnPos = new Vector3(spawnPosition, yPos, 0);
        GameObject obstacule = Instantiate(obstaculeObj, spawnPos, Quaternion.identity);
        Destroy(obstacule, 10f);
    }
}
