using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{

    public Transform Player;
    void LateUpdate()
    {
        Vector3 newposition = Player.position;
        newposition.y = Player.position.y + 10;
        transform.position = newposition;
    }
}
