using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class InputManager : MonoBehaviour
    {
        private Controls controls;
        private Controls.KeyboardActions movementActions;
        private PlayerMovement playerMovement;
        private CameraMovement cameraMovement;
        private GunControll gunControll;

        private void Awake()
        {
            controls = new Controls();
            movementActions = controls.Keyboard;

            playerMovement = GetComponent<PlayerMovement>();
            cameraMovement = GetComponentInChildren<CameraMovement>();
            gunControll = GetComponentInChildren<GunControll>();

            movementActions.Jump.performed += context => playerMovement.Jump();
            //movementActions.Fire.performed += context => gunControll.Fire();
        }

        private void FixedUpdate()
        {
            playerMovement.Move(movementActions.Movement.ReadValue<Vector2>());
            cameraMovement.RotateCamera(movementActions.Camera.ReadValue<Vector2>());
            if(movementActions.Fire.IsPressed()) 
                gunControll.Shoot();
        }
        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }
    }
}