using UnityEngine;

public class HelicopterEnemy : MonoBehaviour
{
    public Transform player;
    public float stopDistance = 10f;
    public float speed = 5f;

    public GameObject bulletPrefab;
    public Transform[] firePoints;
    public float fireRate = 10f; 

    public float zigzagFrequency = 2f;
    public float zigzagAmplitude = 1f;

    public float obstacleCheckDistance = 5f;

    private float nextFireTime;

    void Update()
    {
        if (player == null) return;
        AvoidObstacles();

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            
            Vector3 targetPosition = player.position;

            
            Vector3 zigzagOffset = transform.right * Mathf.Sin(Time.time * zigzagFrequency) * zigzagAmplitude;
            targetPosition += zigzagOffset;

           
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }

        
        Vector3 lookDirection = player.position - transform.position;
        lookDirection.y = 0; 
        if (lookDirection != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    void Shoot()
    {
        foreach (Transform point in firePoints)
        {
            Instantiate(bulletPrefab, point.position, point.rotation);
        }
    }

    void AvoidObstacles()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, obstacleCheckDistance);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Obstacle") || hit.CompareTag("PlayerBullet"))
            {
               
                transform.position += Vector3.up * speed * 2 * Time.deltaTime;
                break;
            }
        }
    }
}