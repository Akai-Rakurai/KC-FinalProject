using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG : MonoBehaviour
{
    public List<GameObject> Spawn = new List<GameObject>();
    void Start()
    {
        GameObject GotoSpawn = Spawn[Random.Range(0,Spawn.Count)];
        Instantiate(GotoSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
