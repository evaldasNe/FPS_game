using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject instructions;
    private void OnGameStart(Collider collider)
    {
        instructions.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            instructions.SetActive(true);
            Animator anim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.E))
                anim.SetTrigger("OpenClose");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")

            instructions.SetActive(false);
    }
}
