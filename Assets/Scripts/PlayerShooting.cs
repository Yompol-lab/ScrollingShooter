using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunLeft;
    public Transform gunRight;
    public float fireRate = 0.1f;
    public float bulletSpeed = 50f;

    private bool isShooting = false;
    private float shootTimer;

    void Update()
    {
        if (isShooting)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                Shoot();
                shootTimer = fireRate;
            }
        }
    }

    
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isShooting = true;
            shootTimer = 0f; 
        }
        else if (context.canceled)
        {
            isShooting = false;
        }
    }

    void Shoot()
    {
        FireBulletFrom(gunLeft);
        FireBulletFrom(gunRight);
    }

    void FireBulletFrom(Transform gun)
    {
        GameObject bullet = Instantiate(bulletPrefab, gun.position, gun.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = gun.forward * bulletSpeed;
        }
    }
}
