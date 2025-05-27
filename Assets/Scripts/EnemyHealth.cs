using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject prefabAlMorir;

    private GameManager gameManager;

    [System.Obsolete]
    void Start()
    {
        currentHealth = maxHealth;
        gameManager = GameObject.FindObjectOfType<GameManager>(); 
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (prefabAlMorir != null)
        {
            GameObject objetoMuerte = Instantiate(prefabAlMorir, transform.position, Quaternion.identity);

            Transform bloquePadre = transform.parent;

            while (bloquePadre != null && bloquePadre.GetComponent<MoveBlock>() == null)
            {
                bloquePadre = bloquePadre.parent;
            }

            if (bloquePadre != null)
            {
                objetoMuerte.transform.SetParent(bloquePadre);
            }
        }

        if (gameManager != null) 
        {
            gameManager.EnemyDefeated(); 
        }

        Destroy(gameObject);
    }
}
