using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Camera : MonoBehaviour
{
    bool CamAvalibale;
    [SerializeField] float camTimer;
    [SerializeField] float textTimer;
    [SerializeField] float ghostTimer;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] GameObject[] ghosts;

    private WebCamTexture backCam;
    private Texture defaultBackground;

    [SerializeField] RawImage background;
    [SerializeField] AspectRatioFitter fit;

    private void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            description.text = "No camera detected...";
            CamAvalibale = false;
            return;
        }

        for(int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
        }

        if (backCam == null)
        {
            description.text = "Unable to find camera...";
            return;
        }

        backCam.Play();
        background.texture = backCam;

        camTimer = Random.Range(10f, 20f);
        CamAvalibale = true;
    }

    private void Update()
    {
        if (!CamAvalibale)
            return;
        else
        {
            if (camTimer < 0.0f)
            {
                int rndm = Random.Range(0, 4);
                int ghstrndm = Random.Range(0, ghosts.Length);

                if (rndm == 0) 
                {   
                    description.text = "Ghost orbs detected...";

                    int num = PlayerPrefs.GetInt("Orbs");
                    num++;
                    PlayerPrefs.SetInt("Orbs", num);
                }
                else if (rndm == 1) 
                { 
                    description.text = "Random movement detected...";

                    int num = PlayerPrefs.GetInt("Movements");
                    num++;
                    PlayerPrefs.SetInt("Movements", num);
                }
                else if (rndm == 2) 
                { 
                    description.text = "Undefined sounds detected...";

                    int num = PlayerPrefs.GetInt("Entities");
                    num++;
                    PlayerPrefs.SetInt("Entities", num);
                }
                else if (rndm == 3) { description.text = "??+!@)#..<666>,1/666>,++_(@#??/"; }

                ghosts[ghstrndm].SetActive(true);

                ghostTimer = Random.Range(0.5f, 2f);
                textTimer = Random.Range(5f, 10f);
                camTimer = Random.Range(10f, 20f);
            }
            else
                camTimer -= Time.deltaTime;

            if (ghostTimer < 0.0f)
            {
                for (int i = 0; i < ghosts.Length; i++)
                    ghosts[i].SetActive(false);
            }
            else
                ghostTimer -= Time.deltaTime;

            if (textTimer < 0.0f)
                description.text = "";
            else
                textTimer -= Time.deltaTime;
        }
        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f: 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
