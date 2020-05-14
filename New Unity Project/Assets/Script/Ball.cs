using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float bounce = 50;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        m_Rigidbody.AddForce(0, bounce, 0, ForceMode.Impulse);
        bounce= bounce - 10;
    }
}
