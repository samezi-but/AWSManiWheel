using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AWSCommunication : MonoBehaviour
{
    public string url;

    // Use this for initialization
    void Start () {
        StartCoroutine(getManiWheelCounterJSON());
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

    public maniJSON getJSON;

    public void clickCommunicationButton(int wheelCount)
    {
        StartCoroutine(postManiWheelCounterJSON(wheelCount));
    }

    // マニ車のカウントアップするメソッド
    private IEnumerator postManiWheelCounterJSON(int wheelCount)
    {
        maniJSON maniJSONdata = new maniJSON();
        maniJSONdata.keta = 1;
        maniJSONdata.wheelCounter = wheelCount;
        string myjson = JsonUtility.ToJson(maniJSONdata);

        byte[] postData = System.Text.Encoding.UTF8.GetBytes(myjson);
        var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(postData);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        // デバッグに使ったコード
        //text.text = request.responseCode.ToString();
        //errorText.text = request.error;
    }

    // マニ車のカウンタの１桁目を取得するメソッド
    private IEnumerator getManiWheelCounterJSON()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.responseCode);
            if(request.responseCode == 200)
            {
                // あとで使う（JSON)
                //Debug.Log(request.downloadHandler.text);
                getJSON = JsonUtility.FromJson<maniJSON>(request.downloadHandler.text);
                Debug.Log(getJSON.keta);
                Debug.Log(getJSON.wheelCounter);
            }
        }
    }
}
