using UnityEngine;
using System.Collections;
using System.IO;
/// <summary>
/// CSVReader
/// データ保管を別に用意しておきたかったので、CSVを読めるようにしてみた
/// </summary>
public class CSVReader : MonoBehaviour {
	TextAsset data;
	// Use this for initialization
	void Start () {
		// Resources/data01
		data = Resources.Load ("data01") as TextAsset;
		StringReader reader = new StringReader (data.text);
		//Read Header
		string header = reader.ReadLine ();
		string[] headersValue = header.Split (',');
		Debug.Log (header);
		//Read Body
		while (reader.Peek()>-1) {
			string body = reader.ReadLine ();
			string[] values = body.Split (',');
			Debug.Log(body);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
