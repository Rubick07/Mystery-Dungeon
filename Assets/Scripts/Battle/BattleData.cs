using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Battle Data")]
public class BattleData : ScriptableObject
{
    public string battleName;

    public EnemyData enemyData;

    public GameObject enemyPrefab;
}
