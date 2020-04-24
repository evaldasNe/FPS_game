using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float distToGround;

    Rigidbody m_Rigidbody;

    private void OnTriggerEnter(Collider other)
    {
        string hitWhat = other.gameObject.tag;
        if (hitWhat == "Water")
        {
            speed = 5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string hitWhat = other.gameObject.tag;
        if (hitWhat == "Water")
        {
            speed = 10f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        string hitWhat = collision.gameObject.tag;
        if (hitWhat == "Enemy")
        {
            FindObjectOfType<GameManager>().Restart();
        }
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    //every frame
    void Update()
    {
        Jump();
    }

    //every physics step
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.fixedDeltaTime;
        Vector3 newPosition = m_Rigidbody.position + m_Rigidbody.transform.TransformDirection(movement);
        m_Rigidbody.MovePosition(newPosition);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            m_Rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
