using UnityEngine;

public class WinBattleUI : MonoBehaviour
{
    private void Start()
    {
        BattleManager.instance.OnRunClear += BattleManager_OnRunClear; ;

        Hide();
    }

    private void BattleManager_OnRunClear(object sender, System.EventArgs e)
    {
        Show();
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void OnDestroy()
    {
        BattleManager.instance.OnRunClear += BattleManager_OnRunClear; ;
    }
}
