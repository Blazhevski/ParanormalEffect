using UnityEngine;
using TMPro;

public class Info : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Enteties;
    [SerializeField] TextMeshProUGUI Orbs;
    [SerializeField] TextMeshProUGUI Movements;

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("Entities"))
            Enteties.text = "Enteties: " + 0;
        else
            Enteties.text = "Enteties: " + PlayerPrefs.GetInt("Entities");

        if (!PlayerPrefs.HasKey("Orbs"))
            Orbs.text = "Orbs: " + 0;
        else
            Orbs.text = "Orbs: " + PlayerPrefs.GetInt("Orbs");

        if (!PlayerPrefs.HasKey("Movements"))
            Movements.text = "Movements: " + 0;
        else
            Movements.text = "Movements: " + PlayerPrefs.GetInt("Movements");
    }
}
