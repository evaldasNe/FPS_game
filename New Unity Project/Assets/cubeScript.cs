using System.Collections;
using UnityEngine;

public class cubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float yAxis = Random.Range(0f, 1f);
        Vector3 newPosition = new Vector3(0, yAxis, 0);
        gameObject.transform.position += newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
