using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Material
{
    Iron,
    Wood,
    Plastic
}
public class Target : MonoBehaviour
{
    public UnityEvent Destroyed;
    public Material material;
    public int healthPoints = 100;

    public void TakeDamage(int damage, Material targetMaterial)
    {
        if(material == targetMaterial)
        {
            healthPoints -= damage;
            if (healthPoints <= 0)
                Destroy(gameObject);
        }
    }

    public void OnDestroy() 
    {
        Destroyed?.Invoke();
        Debug.Log("done");
    }

}
