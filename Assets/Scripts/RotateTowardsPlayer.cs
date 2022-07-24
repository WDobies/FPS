using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Rotate();
    }

    //rotate object towards player
    void Rotate()
    {
        var direction = transform.position - player.transform.position;
        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }
}
