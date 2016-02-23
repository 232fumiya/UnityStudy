using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class getGPS : MonoBehaviour
{
	private GoogleMapGPS googlemap;
	private Text textGPS;
	void Start()
	{
		textGPS = GameObject.Find ("GPS").GetComponent<Text> ();
		StartCoroutine("testGPS");
	}
	IEnumerator testGPS()
	{
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;
		
		// Start service before querying location
		Input.location.Start(5f,5f);
		
		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		
		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			print("Timed out");
			yield break;
		}
		
		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			print("Unable to determine device location");
			yield break;
		}
		else
		{
			// Access granted and location value could be retrieved
			textGPS.text=	"緯度："		+Input.location.lastData.latitude			+"\n"+
							"経度："		+Input.location.lastData.longitude			+"\n"+
							"高度："		+Input.location.lastData.altitude			+"\n"+
							"水平精度：" 	+Input.location.lastData.horizontalAccuracy +"\n"+
							"垂直精度："	+Input.location.lastData.verticalAccuracy	+"\n"+
							"タイムスタンプ："	+ Input.location.lastData.timestamp;
		}
		
		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
	}
}