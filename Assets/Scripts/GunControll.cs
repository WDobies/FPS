using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControll : MonoBehaviour
{
    public Material destroyableMaterial;
    public float fireRate = 0.3f;
    public int damage = 20;
    public Transform rifleTransform;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private GameObject fireParticle;

    private Ray     ray;
    private Vector2 screenCenter;
    private bool    canShoot = true;

    private void Awake()
    {     
        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        InvokeRepeating("Rep", 0.0f, fireRate);
    }

    private void OnEnable()
    {
        InputManager.OnFirePressed += Shoot;
    }
    public void Shoot()
    {
        Instantiate(fireParticle, rifleTransform.position, rifleTransform.rotation);
        ray = Camera.main.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, targetMask))
        {
            if (canShoot)
            {
                canShoot = false;
                Instantiate(hitParticle, raycastHit.point, raycastHit.transform.rotation);
                Target target = raycastHit.transform.GetComponent<Target>();

                if (target)
                {
                    target.TakeDamage(damage, destroyableMaterial);
                }
            }
        }
        else
        {
            //debugTransform.position = ray.GetPoint(100);            
        }
    }

    void Rep()
    {
        canShoot = true;
    }

    private void OnDisable()
    {
        InputManager.OnFirePressed -= Shoot;
    }
}