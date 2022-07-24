using TMPro;
using UnityEngine;
using UnityEngine.Events;

public enum Material
{
    Iron,
    Wood,
    Cardboard
}

public class Target : MonoBehaviour
{
    public UnityEvent OnTargetDestroy;
    public Material   material;
    public int        durabilityPoints = 100;

    [SerializeField] private TextMeshProUGUI materialText;
    [SerializeField] private TextMeshProUGUI durabilityText;

    private void Awake()
    {
        UpdateText();
    }

    public void TakeDamage(int damage, Material gunMaterial)
    {
        //if material set on gun equals material set on a target remove durability points
        if (material == gunMaterial)
        {
            durabilityPoints -= damage;
            if (durabilityPoints <= 0)
                Destroy(gameObject);

            UpdateText();
        }
    }

    public void OnDestroy()
    {
        OnTargetDestroy?.Invoke();
    }

    public void UpdateText()
    {
        materialText.SetText(material.ToString());
        durabilityText.SetText(durabilityPoints.ToString());
    }
}
