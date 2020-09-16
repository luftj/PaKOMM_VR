using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class httptest : MonoBehaviour
{
    public GameObject output;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private string t = "";

    // Update is called once per frame
    void Update()
    {
        //makeRequest(this.gameObject);
        Text textObject = output.GetComponent<Text>();
        textObject.text = Time.time + ":" + t;
    }

    public void makeRequest(float x, float y, string type)
    {
        string query = "http://192.168.137.1:5000/?pos_x=" + x + "&pos_y=" + y + "&type=" + type;
        StartCoroutine(GetRequest(query));
        Debug.Log(query);
        Debug.Log("Update --- " + t);
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                t = webRequest.downloadHandler.text;
            }
        }
    }
}
