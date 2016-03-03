using UnityEngine;
using System.Collections;

public class sampleLine : MonoBehaviour {
	bool isSending=false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
			StartCoroutine ("send");
	}
	IEnumerator send()
	{
		if (isSending)
			yield break;
		else
			isSending = true;
		string message = "Unityから投稿するテスト";
		Application.OpenURL("http://line.naver.jp/R/msg/text/?" + WWW.EscapeURL(message, System.Text.Encoding.UTF8));yield return null;
		isSending = false;
	}
}
