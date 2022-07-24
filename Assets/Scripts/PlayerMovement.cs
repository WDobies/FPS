using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
internal class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 input)
    {
        playerRigidbody.AddForce(((transform.forward * input.y) + (transform.right * input.x)) * movementSpeed * Time.deltaTime, ForceMode.Force);
    }
}
