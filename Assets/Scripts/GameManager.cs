using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemiesDefeated = 0;
    public int enemiesToDefeatForBoss = 10;

    public GameObject bossPrefab;
    public Transform bossSpawnPoint;

    private bool bossSpawned = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;

        if (enemiesDefeated >= enemiesToDefeatForBoss && !bossSpawned)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
        bossSpawned = true;
    }
}
