using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject RadarButton;
    [SerializeField] GameObject CameraButton;
    [SerializeField] GameObject FilmsButton;

    [SerializeField] GameObject RadarPanel;
    [SerializeField] GameObject CameraPanel;
    [SerializeField] GameObject FilmsPanel;

    [SerializeField] GameObject InfoButton;
    [SerializeField] GameObject InfoPanel;

    private void Start()
    {
        RadarPanel.SetActive(true);
        CameraPanel.SetActive(false);
        FilmsPanel.SetActive(false);

        selectPanel(0);
    }

    public void toggleInfoPanel(int state)
    {
        if (state == 1)
        {
            InfoButton.SetActive(false);
            InfoPanel.SetActive(true);

            RadarPanel.SetActive(false);
            CameraPanel.SetActive(false);
            FilmsPanel.SetActive(false);

            RadarButton.GetComponent<Button>().interactable = false;
            FilmsButton.GetComponent<Button>().interactable = false;
            CameraButton.GetComponent<Button>().interactable = false;

            RadarButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            RadarButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;

            FilmsButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            FilmsButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;

            CameraButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            CameraButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;
        }
        else if(state == 2)
        {
            InfoPanel.SetActive(false);
            InfoButton.SetActive(true);

            RadarPanel.SetActive(true);

            RadarButton.GetComponent<Button>().interactable = true;
            FilmsButton.GetComponent<Button>().interactable = true;
            CameraButton.GetComponent<Button>().interactable = true;

            RadarButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
            RadarButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.green;

            FilmsButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            FilmsButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;

            CameraButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            CameraButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    public void selectPanel(int index)
    {
        if (index == 0)
        {
            RadarPanel.SetActive(true);
            CameraPanel.SetActive(false);
            FilmsPanel.SetActive(false);

            RadarButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
            RadarButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.green;

            FilmsButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            FilmsButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;

            CameraButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            CameraButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;
        }
        else if (index == 1)
        {
            RadarPanel.SetActive(false);
            CameraPanel.SetActive(true);
            FilmsPanel.SetActive(false);

            CameraButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
            CameraButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.green;

            RadarButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            RadarButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;

            FilmsButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            FilmsButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;
        }
        else if(index == 2)
        {
            RadarPanel.SetActive(false);
            CameraPanel.SetActive(false);
            FilmsPanel.SetActive(true);

            FilmsButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
            FilmsButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.green;

            RadarButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            RadarButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;

            CameraButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            CameraButton.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
