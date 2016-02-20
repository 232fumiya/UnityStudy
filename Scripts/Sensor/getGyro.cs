using UnityEngine;
using System.Collections;

public class getGyro : MonoBehaviour {
	// Use this for initialization
	Quaternion smartGyro=new Quaternion (0.7f, 0.0f, 0.0f, 0.7f);
	void Start () 
	{
		Input.gyro.enabled = true;//Trueにしとかないとセンサ値取り出せない
		Input.gyro.updateInterval = 0.1f;
	}
	void Update()
	{
		//センサ値取得
		Quaternion gyro=Input.gyro.attitude;
		//基準を下から前方向にし、XとYの回転を逆転させる
		smartGyro = new Quaternion (0.7f, 0.0f, 0.0f, 0.7f) * (new Quaternion (-gyro.x, -gyro.y, gyro.z, gyro.w));
		this.transform.localRotation =smartGyro;
	}
	void OnApplicationQuit() 
	{
		Input.gyro.enabled = false;
	}
}
