using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] List<GameObject> guns;

    public void switchGun(string keyName)
    {
        //substract 1 from key name to fit positions on the list
        int key = int.Parse(keyName) - 1;

        //enable gun which position on list == pressed key number, disable all the others
        if (!guns[key].activeInHierarchy)
        {
            foreach (GameObject item in guns)
            {
                item.SetActive(false);
            }
            guns[key].SetActive(true);
        }
    }
}
