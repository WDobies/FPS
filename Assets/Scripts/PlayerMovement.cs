using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    public float movementSpeed;
    public int jumpStrenght;
    private bool isGrounded = false;

    void Update()
    {
        if (Input.GetKey("w"))
            rb.transform.position += transform.forward * movementSpeed * Time.deltaTime;  

        if (Input.GetKey("s"))
            rb.transform.position += -transform.forward * movementSpeed * Time.deltaTime;

        if (Input.GetKey("a"))
            rb.transform.position += -transform.right * movementSpeed * Time.deltaTime;

        if (Input.GetKey("d"))
            rb.transform.position += transform.right * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown("space") && isGrounded)
            rb.AddForce(transform.up * jumpStrenght);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
            isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
            isGrounded = false;
    }
}
