using UnityEngine;
using TMPro;

public class Radaer : MonoBehaviour
{
    [SerializeField] GameObject[] Dots;
    [SerializeField] TextMeshProUGUI Description;

    [SerializeField]  float startTimer;
    [SerializeField]  float DotsActiveTimer;
    bool DotsDeactivated = false;
    void Start()
    {
        for (int i = 0; i < Dots.Length; i++)
            Dots[i].SetActive(false);

        startTimer = Random.Range(5f, 20f);
        DotsActiveTimer = 0.0f;
    }

    void Update()
    {
        if (startTimer <= 0.0f)
        {
            int OneOrTwo = Random.Range(0, 5);

            if (OneOrTwo < 4)
            {
                int rndmDot = Random.Range(0, Dots.Length);
                Dots[rndmDot].SetActive(true);

                DotsActiveTimer = Random.Range(6f, 15f);
                DotsDeactivated = false;

                int rndmText = Random.Range(0, 3);

                if (rndmText == 0)
                {
                    Description.text = "Entety detected around you...";

                    int num = PlayerPrefs.GetInt("Entities");
                    num++;
                    PlayerPrefs.SetInt("Entities", num);
                }
                else if (rndmText == 1)
                {
                    Description.text = "Spirit orbs around you...";

                    int num = PlayerPrefs.GetInt("Orbs");
                    num++;
                    PlayerPrefs.SetInt("Orbs", num);
                }
                else if (rndmText == 2)
                {
                    Description.text = "Undefined movement detected...";

                    int num = PlayerPrefs.GetInt("Movements");
                    num++;
                    PlayerPrefs.SetInt("Movements", num);
                }
            }
            else
            {
                int rndmDotOne = Random.Range(0, Dots.Length);
                int rndmDotTwo = Random.Range(0, Dots.Length);
                Dots[rndmDotOne].SetActive(true);
                Dots[rndmDotTwo].SetActive(true);

                DotsActiveTimer = Random.Range(6f, 15f);
                DotsDeactivated = false;

                int rndmText = Random.Range(0, 2);

                if (rndmText == 0)
                {
                    Description.text = "Multiple enteties detected around you...";

                    int num = PlayerPrefs.GetInt("Entities");
                    num += 2;
                    PlayerPrefs.SetInt("Entities", num);
                }
                else if (rndmText == 1)
                {
                    Description.text = "Multiple movements detected.";

                    int num = PlayerPrefs.GetInt("Movements");
                    num+=2;
                    PlayerPrefs.SetInt("Movements", num);
                }

            }

            startTimer = Random.Range(15f, 25f);
        }
        else
            startTimer -= Time.deltaTime;

        if (DotsActiveTimer > 0.0f)
            DotsActiveTimer -= Time.deltaTime;
        else
        {
            if (!DotsDeactivated)
            {
                for (int i = 0; i < Dots.Length; i++)
                    Dots[i].SetActive(false);

                Description.text = "Searching...";

               DotsDeactivated = true;
            }
        }
    }
}
