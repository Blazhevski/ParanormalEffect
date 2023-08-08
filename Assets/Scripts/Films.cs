using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

[System.Serializable]
public class Data
{
    public string Name;
    public string Rating;
}
[System.Serializable]
public class DataList
{
    public Data[] items;
}

public class Films : MonoBehaviour
{
    [SerializeField] GameObject[] FilmsPanels;

    string jsonURL = "https://drive.google.com/uc?export=download&id=1D9IFS3oOvIO7br8DqNH54GFAm4Hc32Hn";
    void Start()
    {
        StartCoroutine(getName(jsonURL));
    }

    IEnumerator getName(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.Send();
        if (request.isNetworkError) { }
        else
        {
            string json = request.downloadHandler.text;
            DataList dataList = JsonUtility.FromJson<DataList>("{\"items\":" + json + "}");
            int i = 0;
            foreach (Data individual in dataList.items)
            {
                FilmsPanels[i].SetActive(true);
                FilmsPanels[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = individual.Name;
                FilmsPanels[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text ="Rating: " +  individual.Rating;
                i++;
            }
        }
        request.Dispose();
    }
}
