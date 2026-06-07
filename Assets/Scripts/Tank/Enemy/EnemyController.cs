using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Tank tank;
    [SerializeField] private CannonSystem cannon;

    public Tank Tank => tank;
    public CannonSystem Cannon => cannon;
}
