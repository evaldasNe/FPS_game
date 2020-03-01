using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargets : MonoBehaviour
{
    public float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the cube  from(0,0,0) to (5,0,0) and back to (0,0,0) and so on.
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 20), transform.position.y, transform.position.z);
    }
}
