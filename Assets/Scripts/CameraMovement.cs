using UnityEngine;


public class CameraMovement : MonoBehaviour
{   
    [SerializeField] private float sensitivity;

    private GameObject player;
    private float yRotation;
    private float xRotation;

    void Awake()
    {
        //hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void RotateCamera(Vector2 input)
    {
        float mouseX = input.x * Time.deltaTime * sensitivity;
        float mosueY = input.y * Time.deltaTime * sensitivity;

        yRotation += mouseX;
        xRotation -= mosueY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //rotate player on Y axis
        player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        //rotate camera only on X axis
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
