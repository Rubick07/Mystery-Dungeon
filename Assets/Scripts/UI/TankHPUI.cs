using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankHPUI : MonoBehaviour
{
    [SerializeField] private Tank tank;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Image hpBarImage;
    [SerializeField] private bool isEnemy;

    private void Awake()
    {
        if (isEnemy)
        {
            EnemySpawner.OnNewEnemySpawn += EnemySpawner_OnNewEnemySpawn;
            Debug.Log("Masuk");
            return;
        }
    }

    private void Start()
    {
        if (isEnemy)
        {
            return;
        }

        tank.OnTankHpChanged += Tank_OnTankHpChanged;
    }

    private void EnemySpawner_OnNewEnemySpawn(object sender, Tank e)
    {
        tank = e;
        tank.OnTankHpChanged += Tank_OnTankHpChanged;

        Debug.Log("Test");
        Refresh();
    }

    private void Tank_OnTankHpChanged(object sender, System.EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        hpText.text = tank.currentHealth.ToString() + "/" + tank.GetMaxHP().ToString();

        hpBarImage.fillAmount = tank.GetHealthNormalized();
    }

    private void OnDestroy()
    {
        EnemySpawner.OnNewEnemySpawn -= EnemySpawner_OnNewEnemySpawn;
        tank.OnTankHpChanged -= Tank_OnTankHpChanged;
    }


}
