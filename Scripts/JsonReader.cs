using UnityEngine;
using System.Collections;
using MiniJSON;
/// <summary>
/// JsonReader.cs
/// JSONデータの取得を試してみる。
/// MiniJSON.csが必要です。
/// </summary>
public class JsonReader : MonoBehaviour {
	TextAsset sampleJson;
	// Use this for initialization
	void Start () {
		sampleJson = Resources.Load ("data")as TextAsset;
		var jsonText = sampleJson.text;
		var data=(IDictionary)MiniJSON.Json.Deserialize(jsonText);
		Debug.Log(data["name"]);
		Debug.Log(data["age"]);
		Debug.Log(data["bloodType"]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
