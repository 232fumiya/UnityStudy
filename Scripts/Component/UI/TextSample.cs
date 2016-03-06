using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextSample : MonoBehaviour {
	private Text tex;
	// Use this for initialization
	void Start () {
		tex = GameObject.Find ("Text").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		tex.text="";
	}
}
