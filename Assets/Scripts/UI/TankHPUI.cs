using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankHPUI : MonoBehaviour
{
    [SerializeField] private Tank tank;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Image hpBarImage;

    private void Start()
    {
        hpText.text = tank.currentHealth.ToString() + "/" + tank.GetMaxHP().ToString();

        tank.OnTankHpChanged += Tank_OnTankHpChanged;
    }

    private void Tank_OnTankHpChanged(object sender, System.EventArgs e)
    {
        hpText.text = tank.currentHealth.ToString() + "/"+ tank.GetMaxHP().ToString();

        hpBarImage.fillAmount = tank.GetHealthNormalized();
    }


}
