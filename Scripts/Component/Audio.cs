using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	AudioSource sample;
	// Use this for initialization
	void Start () {
		sample = this.GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!sample.isPlaying&&Input.GetKeyDown(KeyCode.A))
			sample.Play ();
	}
}
