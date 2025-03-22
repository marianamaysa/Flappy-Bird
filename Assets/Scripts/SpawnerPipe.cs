using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private float heightRange;
    [SerializeField] private GameObject pipeObj;
    //[SerializeField] private GameObject pipeObjClone;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pipe = Instantiate(pipeObj, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}
