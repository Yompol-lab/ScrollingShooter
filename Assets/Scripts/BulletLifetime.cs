using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime); 
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); 
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); 
            Destroy(gameObject);       
        }
    }
}
