using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1);
    }
}
