using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrewUI : MonoBehaviour
{
    [SerializeField] private Image crewImage;
    [SerializeField] private TextMeshProUGUI crewNameText;
    ActiveCrew activeCrew;

    public void Setup(ActiveCrew activeCrew)
    {
        this.activeCrew = activeCrew;

        crewImage.sprite = activeCrew.Data.portrait;
        crewNameText.text = activeCrew.Data.crewName;
    }

    public ActiveCrew GetActiveCrew() => activeCrew;

}
