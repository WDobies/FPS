using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private TextMeshProUGUI materialText;
    [SerializeField] private TextMeshProUGUI durabilityText;

    public UnityEvent Destroyed;
    public Material material;
    public int healthPoints = 100;
    private void Awake()
    {
        UpdateText();
    }
    public void TakeDamage(int damage, Material targetMaterial)
    {
        Debug.Log(targetMaterial);
        if(material == targetMaterial)
        {
            healthPoints -= damage;

            if (healthPoints <= 0)
                Destroy(gameObject);
            UpdateText();
        }
    }

    public void OnDestroy() 
    {
        Destroyed?.Invoke();
        Debug.Log("done");
    }

    public void UpdateText()
    {
        materialText.SetText(material.ToString());
        durabilityText.SetText(healthPoints.ToString());
    }
}
