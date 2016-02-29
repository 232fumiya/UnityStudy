using UnityEngine;
using System.Collections;
/// <summary>
/// Send test.
/// formでデータを投げる
/// </summary>
public class sendTest : MonoBehaviour {
	private string message="message";
	// Use this for initialization
	void Start () {
		StartCoroutine ("sendDataTest");
	}

	private IEnumerator sendDataTest()
	{
		string URL = "データを飛ばすurl";
		WWWForm form = new WWWForm ();
		//受け取り側はsendDataTest.phpを参照して下さい・
		form.AddField("test",message);
		//受け取り側はSampleSendImage.phpを参照して下さい・
		form.AddBinaryData("image",bytes,"img.png","image/png");
		WWW www = new WWW (URL,form);
		yield return www;
		if (www.error != null)
			Debug.Log (www.error);
		else
			Debug.Log("success!");
	}
}
