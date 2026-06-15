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


        GameObject enemyObj = Instantiate(battleData.enemyPrefab,spawnPoint.position, spawnPoint.rotation);

        currentEnemy = enemyObj.GetComponent<Tank>();

        EnemyBrain enemyBrain = enemyObj.GetComponent<EnemyBrain>();
        enemyBrain.Initialized(battleData.enemyData);

        currentEnemy.Initialized(battleData.enemyData.maxHP);

        OnNewEnemySpawn?.Invoke(this, currentEnemy);

        return currentEnemy;
    }

    public Tank GetCurrentEnemyTank() => currentEnemy;
}
