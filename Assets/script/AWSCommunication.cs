using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AWSCommunication : MonoBehaviour
{
    // 1データあたりの最大カウンタ
    private const ulong maniCounterLimit = 999999999999;
    public string url;
    public ulong masterCounter = 0;
    public float getTime = 10.0f;

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
        public ulong wheelCounter;
    }

    public maniJSON getJSON;

    public void AWSManiwheelCountUp(ulong wheelCount)
    {
        StartCoroutine(postManiWheelCounterJSON(wheelCount));
    }

    // AWSのマニ車のカウントアップするメソッド
    private IEnumerator postManiWheelCounterJSON(ulong wheelCount)
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

    public void startGetWheelCount()
    {
        StartCoroutine(getLoopManiWheelCounterJSON());
    }

    private IEnumerator getLoopManiWheelCounterJSON()
    {
        while (true) {
            StartCoroutine(getManiWheelCounterJSON());
            yield return new WaitForSeconds(getTime);
        }
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
                Debug.Log(request.downloadHandler.text);
                getJSON = JsonUtility.FromJson<maniJSON>(request.downloadHandler.text);
                Debug.Log(getJSON.keta);
                Debug.Log(getJSON.wheelCounter);
                masterCounter = getJSON.wheelCounter;
            }
        }
    }
}
