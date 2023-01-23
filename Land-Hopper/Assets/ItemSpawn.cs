using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    Vector3 spawnPosition;
    public GameObject[] Items;

    private void Start()
    {
        SpawnItem();
    }

    
    public void SpawnItem()
    {
        GameObject item = Items[Random.Range(0, Items.Length)];
        Instantiate(item, transform.position, Quaternion.identity);
    }
}
