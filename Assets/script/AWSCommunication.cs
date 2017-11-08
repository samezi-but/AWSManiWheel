using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AWSCommunication : MonoBehaviour
{
    public string url;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    // マニ車のJSONのデータ構造
    public class maniJSON
    {
        public int keta;
        public int wheelCounter;
    }

    public void clickCommunicationButton(int wheelCount, int keta)
    {
        StartCoroutine(postManiWheelCounterJSON(wheelCount,keta));
    }

    private IEnumerator postManiWheelCounterJSON(int wheelCount, int keta)
    {
        maniJSON maniJSONdata = new maniJSON();
        maniJSONdata.keta = keta;
        maniJSONdata.wheelCounter = wheelCount;
        string myjson = JsonUtility.ToJson(maniJSONdata);

        byte[] postData = System.Text.Encoding.UTF8.GetBytes(myjson);
        var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(postData);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        //text.text = request.responseCode.ToString();
        //errorText.text = request.error;
    }
}
