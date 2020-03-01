using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunController : MonoBehaviour
{
    float lookSensitivity = 1.5f;
    float smoothing = 1.5f;
    float targetcount = 0;

    GameObject player;
    Vector2 smoothedVelocity;
    Vector2 currentLokingPos;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        CheckForShooting();

    }

    private void RotateGun()
    {
        Vector2 inputValues = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        inputValues = Vector2.Scale(inputValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValues.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValues.y, 1f / smoothing);

        currentLokingPos += smoothedVelocity;

        transform.localRotation = Quaternion.AngleAxis(-currentLokingPos.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(currentLokingPos.x, player.transform.up);
    }

    private void CheckForShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit whatIHit;
            if(Physics.Raycast(transform.position, transform.forward, out whatIHit, Mathf.Infinity))
            {
               Debug.Log(whatIHit.collider.name);
                if(whatIHit.collider.name == "Shooting-wall")
                {
                    Destroy(whatIHit.transform.gameObject);

                }
                if (whatIHit.collider.name == "Target")
                {
                    targetcount++;
                    Destroy(whatIHit.transform.gameObject);
                    Debug.Log("Nušauti taikiniai: " + targetcount + "/5" );
                }
            }
        }
    }
}
