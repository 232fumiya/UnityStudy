using UnityEngine;
using System.Collections;

public class sampleTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("enter:"+other.name);
	}
	void OnTriggerStay(Collider other)
	{
		Debug.Log ("stay:"+other.name);
	}
	void OnTriggerExit(Collider other)
	{
		Debug.Log ("exit:"+other.name);
	}
}
