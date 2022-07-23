using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    internal class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float sensitivity;
        [SerializeField] private Transform playerTransform;

        private float yRotation;
        private float xRotation;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void RotateCamera(Vector2 input)
        {
            float mouseX = input.x * Time.deltaTime * sensitivity;
            float mosueY = input.y * Time.deltaTime * sensitivity;

            yRotation += mouseX;
            xRotation -= mosueY;

            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerTransform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
