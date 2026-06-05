using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Battle Data")]
public class BattleData : ScriptableObject
{
    public string battleName;

    public int enemyHP;

    public GameObject enemyPrefab;
}
