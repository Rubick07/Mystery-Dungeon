using UnityEngine;

public class DamageTextAction : MonoBehaviour
{
    [SerializeField] Transform damageTextPrefab;
    private Tank tank;

    private void Awake()
    {
        tank = GetComponent<Tank>();
    }

    private void Start()
    {
        tank.OnTankTakeDamage += Tank_OnTankTakeDamage;
    }

    private void Tank_OnTankTakeDamage(object sender, System.EventArgs e)
    {
        Transform damageTextTransform = Instantiate(damageTextPrefab, transform);

        Vector3 offset = new Vector3(0.898f, 0.319f, 1f);

        damageTextTransform.localPosition = offset;

        DamageText damageText = damageTextTransform.GetComponent<DamageText>();
        damageText.SetUp(tank.GetLastDamageValue());

        Destroy(damageTextTransform.gameObject, 1f);
    }


    private void OnDestroy()
    {
        tank.OnTankTakeDamage += Tank_OnTankTakeDamage;
    }
}
