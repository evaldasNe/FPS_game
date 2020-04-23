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
        var transform = GetComponent<Transform>();
        Vector3 v = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
        transform.localEulerAngles = v;
    }
}
