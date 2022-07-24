using UnityEngine;

public class Gun : MonoBehaviour
{
    public float        fireRate = 0.3f;
    public int          damage = 20;
    public Transform    rifleTransform;
    public Material     destroyableMaterial;

    [SerializeField] private LayerMask  targetMask;
    [SerializeField] private GameObject bulletParticle;
    [SerializeField] private GameObject muzzleFlashParticle;

    private Ray     ray;
    private Vector2 screenCenter;
    private bool    canShoot = true;
    private void Awake()
    {
        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        InvokeRepeating("ResetShooting", 0.0f, fireRate);
    }
    public void Shoot()
    {
        Instantiate(muzzleFlashParticle, rifleTransform.position, rifleTransform.rotation);

        ray = Camera.main.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, targetMask) && canShoot)
        {
                canShoot = false;
                Instantiate(bulletParticle, raycastHit.point, raycastHit.transform.rotation);
                Target target = raycastHit.transform.GetComponent<Target>();
                if (target)
                    target.TakeDamage(damage, destroyableMaterial);
            
        }
    }
    private void ResetShooting()
    {
        canShoot = true;
    }

    private void OnEnable()
    {
        InputManager.OnFirePressed += Shoot;
    }

    private void OnDisable()
    {
        InputManager.OnFirePressed -= Shoot;
    }
}