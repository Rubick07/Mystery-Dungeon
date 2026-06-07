using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;

    public int maxHP;

    public List<CardData> cards;

    public float attackInterval;
}
