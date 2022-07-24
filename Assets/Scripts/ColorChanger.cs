using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    //generate and set random color for material
    public void GenerateColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}
