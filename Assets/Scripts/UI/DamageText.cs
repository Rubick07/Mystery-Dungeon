using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TMP_Text meshPro;

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }

    public void SetUp(int damageValue)
    {
        meshPro.text = damageValue.ToString();
    }

}
