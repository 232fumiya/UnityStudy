using UnityEngine;
using System.Collections;

public class SampleAddForce : MonoBehaviour {
	Rigidbody rigid;
	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)) {
		rigid.AddForce(Vector3.right,ForceMode.Acceleration);
		}
		else if (Input.GetKey(KeyCode.F)) {
			rigid.AddForce(Vector3.right,ForceMode.Force);
		}
		else if (Input.GetKey(KeyCode.I)) {
			rigid.AddForce(Vector3.right,ForceMode.Impulse);
		}
		else if (Input.GetKey(KeyCode.V)) {
			rigid.AddForce(Vector3.right,ForceMode.VelocityChange);
		}

	}
}
