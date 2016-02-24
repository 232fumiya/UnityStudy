using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Get compass.
/// Canvas/Textにアタッチして使ってください。
/// </summary>
public class getCompass : MonoBehaviour {
	private Text text; 
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
		//trueにしないと0を返し続ける。
		Input.compass.enabled = true;
		//毎フレーム呼ぶ必要なさそう？なのでコルーチンで管理
		StartCoroutine ("getCompassData");
	}
	IEnumerator getCompassData()
	{
		while(true)
		{
			//Androidで確認できるようにUI使って表示する
			//0が北を意味する　90=東　180=南　270=西
			text.text=Input.compass.magneticHeading.ToString();
			//更新頻度
			yield return new WaitForSeconds(1f);
		}
	}
	void OnApplicationQuit() 
	{
		//使い終わったらちゃんとfalse返してあげる
		Input.compass.enabled = false;
	}
}
