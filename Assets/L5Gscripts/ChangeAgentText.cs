using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAgentText : MonoBehaviour
{

	public Text text;
	private string originalText;

	// Use this for initialization
	void Start()
	{
		originalText = text.text;
	}

	

	public void ChangeText(string message)
    {
		text.text = message;
		Debug.Log(message);
	}

	public void BackToOriginalText()
    {
		text.text = originalText;
    }

	

			

}