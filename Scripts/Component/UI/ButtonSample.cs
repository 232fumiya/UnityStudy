using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonSample : MonoBehaviour {

	private Button button1;
	// Use this for initialization
	void Start () {
		button1=this.GetComponent<Button> ();
		button1.onClick.AddListener (testClickListener);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void testClickListener()
	{

	}
}
