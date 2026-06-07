using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public static event EventHandler<Tank> OnNewEnemySpawn;

    [SerializeField] private Transform spawnPoint;

    private Tank currentEnemy;

    public Tank SpawnEnemy(BattleData battleData)
    {
        if (currentEnemy != null)
        {
            Destroy(currentEnemy.gameObject);
        }

        Debug.Log("Spawn Enemy");

        GameObject enemyObj = Instantiate(battleData.enemyPrefab,spawnPoint.position, spawnPoint.rotation);

        currentEnemy = enemyObj.GetComponent<Tank>();

        currentEnemy.Initialized(battleData.enemyHP);

        OnNewEnemySpawn?.Invoke(this, currentEnemy);

        return currentEnemy;
    }
}
