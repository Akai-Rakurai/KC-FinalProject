using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Vector3 spawnValues;
    float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    int SpawnedAmount;

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnMostWait, spawnLeastWait);
    }

    IEnumerator waitSpawner()
    {
        yield
        return new WaitForSeconds(startWait);

        while (!stop)
        {

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1f, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(Enemy, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            SpawnedAmount++;
            if(SpawnedAmount >= 10)
                stop = true;

            yield
            return new WaitForSeconds(spawnWait);
        }
    }
}  
