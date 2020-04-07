using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameObject.Find("Player Camera").transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + player.forward);
    }
}
