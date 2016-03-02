using UnityEngine;
using System.Collections;

public class sampleTwitter : MonoBehaviour {
	bool isTweeting=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
			StartCoroutine ("tweet");
	}
	IEnumerator tweet()
	{
		if (isTweeting)
			yield break;
		else
			isTweeting = true;
		Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL("テキスト #hashtag"));
		yield return null;
		isTweeting = false;
	}
}
