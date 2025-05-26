using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;

    public GameObject bulletPrefab;
    public Transform[] firePoints;
    public float fireRate = 1f;
    private float nextFireTime;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        foreach (Transform point in firePoints)
        {
            Instantiate(bulletPrefab, point.position, point.rotation);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        SceneManager.LoadScene("Victory");
    }
}
