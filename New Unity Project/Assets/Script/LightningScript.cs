using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var hitObject = other.gameObject.tag;
        if (hitObject == "Player")
        {
            FindObjectOfType<GameManager>().Restart();
        }
    }
}
