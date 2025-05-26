using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    public float lifeTime = 3f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    [System.Obsolete]
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            HelicopterEnemy enemy = other.GetComponent<HelicopterEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

       
        if (other.CompareTag("Boss"))
        {
            BossEnemy boss = other.GetComponent<BossEnemy>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
