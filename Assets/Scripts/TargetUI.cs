using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetUI : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        var direction = transform.position - playerTransform.position;
        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }
}
