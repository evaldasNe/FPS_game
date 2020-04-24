using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerGunController : MonoBehaviour
{
    float lookSensitivity = 1.5f;
    float smoothing = 1.5f;
    int killCount;
    int enemysCount;
    private TextMeshProUGUI m_Text;

    int damage = 25;
    float impactForce = 35f;
    float fireRate = 15f;
    float nextTimeToFire = 0f;

    ParticleSystem muzzleFlash;
    GameObject player;
    Vector2 smoothedVelocity;
    Vector2 currentLokingPos;

    AudioSource shootingAudio;

    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = transform.GetComponentInChildren<ParticleSystem>();
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        m_Text = GameObject.Find("Counter (TMP)").GetComponent<TextMeshProUGUI>();
        enemysCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        killCount = 0;
        m_Text.text = "0 / " + enemysCount;

        shootingAudio = GetComponent<AudioSource>();
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
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            muzzleFlash.Play();
            shootingAudio.Play();

            RaycastHit whatIHit;
            if(Physics.Raycast(transform.position, transform.forward, out whatIHit, Mathf.Infinity))
            {
                string shotObjectName = whatIHit.collider.name;
                Debug.Log(shotObjectName);
                
                if(shotObjectName == "Shooting-wall")
                {
                    Destroy(whatIHit.transform.gameObject);

                }
                if (shotObjectName == "Target")
                {
                    killCount++;
                    Destroy(whatIHit.transform.gameObject);
                    IncreaseCounter(killCount);
                    if (killCount == enemysCount)
                    {
                        SceneManager.LoadScene("Level1");
                    }
                } 
                else if(shotObjectName.Contains("Enemy"))
                {
                    
                    if (whatIHit.rigidbody != null)
                    {
                        whatIHit.rigidbody.AddForce(-whatIHit.normal * impactForce);
                    }
                    
                    // true when object dies, else false
                    if (whatIHit.transform.GetComponent<EnemyScript>().TakeDamage(damage))
                    {
                        killCount++;
                        IncreaseCounter(killCount);
                    }
                }

                nextTimeToFire = Time.time + 1f / fireRate;
            }
        }
    }

    void IncreaseCounter(int count)
    {
        m_Text.text = count.ToString() + " / " + enemysCount;
    }
}
