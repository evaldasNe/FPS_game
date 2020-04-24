using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        OpenDoors();
    }

    private void OpenDoors()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("OpenClose");
    }
}
