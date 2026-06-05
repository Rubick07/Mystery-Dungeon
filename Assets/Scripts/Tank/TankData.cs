using UnityEngine;

[CreateAssetMenu(menuName = "Tank/Tank Data")]
public class TankData : ScriptableObject
{
    public string tankName;

    public int baseHP;

    public StarterDeckData starterDeck;
}
