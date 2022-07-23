using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] List<GameObject> guns;

    public void switchGun(string keyName)
    {
        int key = int.Parse(keyName)-1;

        if (!guns[key].active)
        {
            foreach (GameObject item in guns)
            {
                item.SetActive(false);
            }
            guns[key].SetActive(true);
        }
    }
}
