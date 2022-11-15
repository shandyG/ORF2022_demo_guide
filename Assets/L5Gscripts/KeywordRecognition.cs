using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordRecognition : MonoBehaviour
{

    private KeywordController keyCon;
    private TargetTracking tageTra;
    private string[][] keywords;

    public GameObject refObj;
    public GameObject destinationObj;

    private string destinationName;

    string objectName;
    string explainMessage;
    TargetTracking script;
    ChangeAgentText CAscript;


    // Use this for initialization
    void Start()
    {
        keywords = new string[2][];
        keywords[0] = new string[] { "あんない", "あんないして", "はい" };
        keywords[1] = new string[] { "ありがとう", "もういいよ" };


        keyCon = new KeywordController(keywords, true);//keywordControllerのインスタンスを作成
        keyCon.SetKeywords();//KeywordRecognizerにkeywordsを設定する
        keyCon.StartRecognizing(0); //シーン中で音声認識を始めたいときに呼び出す

        

        
    }

    public void ChangeDestinationObj(string destination, GameObject avatar)
    {
        if (destination != null)
        {
            destinationName = destination;
            Debug.Log(destination);
            refObj = avatar;
            script = refObj.GetComponent<TargetTracking>();
        }

        else
        {
            destinationName = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCon.hasRecognized[0])//menu 止まってこっちを向く
        {
            Debug.Log("keyword[0] was recognized");
            keyCon.hasRecognized[0] = false;
            keyCon.StopRecognizing(0);
            keyCon.StartRecognizing(1);
            script.GuideStart();

            if (destinationName != null)
            {
                
                script.SetDestination(destinationName);
                Debug.Log("reach");
            }
        }
        



    }
}
