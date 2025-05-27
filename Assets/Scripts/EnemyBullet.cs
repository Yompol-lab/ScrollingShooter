using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float lifeTime = 5f;
    public float speed = 20f;
    public float damageAmount = 10f;

    private Rigidbody rb;

    [System.Obsolete]
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }
        }


        
    }
}