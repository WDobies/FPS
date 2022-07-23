using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [RequireComponent(typeof(Rigidbody))]
    internal class PlayerMovement : MonoBehaviour
    {
        private Rigidbody playerRigidbody;

        public float movementSpeed;
        public int jumpStrenght;
        private bool isGrounded = false;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        public void Jump()
        {
            if(isGrounded)
                playerRigidbody.AddForce(transform.up * jumpStrenght);
        }

        public void Move(Vector2 input)
        {
            //playerRigidbody.transform.position += transform.forward * input.y * movementSpeed * Time.deltaTime;
            playerRigidbody.AddForce(((transform.forward * input.y) + (transform.right * input.x)) * movementSpeed * Time.deltaTime, ForceMode.Force);
            //playerRigidbody.transform.position += transform.right * input.x * movementSpeed * Time.deltaTime;
            //playerRigidbody.AddForce(transform.right * input.x * movementSpeed * Time.deltaTime, ForceMode.Acceleration);
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
