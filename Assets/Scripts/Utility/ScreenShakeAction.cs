using UnityEngine;

public class ScreenShakeAction : MonoBehaviour
{
    private void Start()
    {
        Tank.OnAnyPlayerTankTakeDamage += Tank_OnAnyPlayerTankTakeDamage;
    }

    private void Tank_OnAnyPlayerTankTakeDamage(object sender, System.EventArgs e)
    {
        ScreenShake.Instance.Shake(3f);
    }

}
