using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;//UnityWebRequestを使うために必要

public class GetWebText : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        /*取得したいサイトURLを指定*/
        UnityWebRequest www = UnityWebRequest.Get("https://orf.sfc.keio.ac.jp/2022/exhibitions/02");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // 結果をテキストとして表示します
            Debug.Log(www.downloadHandler.text);

            //  または、結果をバイナリデータとして取得します
            byte[] results = www.downloadHandler.data;
        }
    }
}

//<h2 class="heading-4">(.*?)</h2>
//<div class="detail-richtext w-richtext"><p>(.*?)</p></div>
//< div class= "info-title-content-content building-number" > (.*?) </ div >
//<div class="div-block-48"><img src="(.*?)"(.*?)></div>
