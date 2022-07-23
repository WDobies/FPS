using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class InputManager : MonoBehaviour
    {
        private Controls controls;
        private Controls.KeyboardActions inputActions;
        private PlayerMovement playerMovement;
        private CameraMovement cameraMovement;
        private GunControll gunControll;
        private Equipment equipment;

        public static Action OnFirePressed;

        private void Awake()
        {
            controls = new Controls();
            inputActions = controls.Keyboard;

            playerMovement = GetComponent<PlayerMovement>();
            cameraMovement = GetComponentInChildren<CameraMovement>();
            gunControll = GetComponentInChildren<GunControll>();
            equipment = GetComponentInChildren<Equipment>();

            inputActions.Jump.performed += context => playerMovement.Jump();
            inputActions.Equipment.performed += context => equipment.switchGun(context.control.name);
        }

        private void FixedUpdate()
        {
           // Debug.Log(movementActions.Equipment.activeControl.name);
            playerMovement.Move(inputActions.Movement.ReadValue<Vector2>());
            cameraMovement.RotateCamera(inputActions.Camera.ReadValue<Vector2>());
        if (inputActions.Fire.IsPressed())
        {
            OnFirePressed?.Invoke();
            //gunControll = GetComponentInChildren<GunControll>();
            //if(gunControll)
                //gunControll.Shoot();
        } 
               
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