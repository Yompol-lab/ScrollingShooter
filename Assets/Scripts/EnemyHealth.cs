using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject prefabAlMorir;

    void Start()
    {
        currentHealth = maxHealth;
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

       

        Destroy(gameObject);
    }
}
