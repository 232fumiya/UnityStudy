using UnityEngine;
using System.Collections;
/// <summary>
/// Google map test.
/// Web接続のやり方を学ぶ。
/// GoogleMapに繋いでみました。
/// </summary>
public class GoogleMapTest : MonoBehaviour {
		GUITexture mapGuiTexture;
		private int width = 300;
		private int height = 200;
		private double latitude=35.681369f;
		private double longitude=139.766052f;
		private int zoom = 200;
		private int x=0;
		private int y=0;
		void Start () {
			mapGuiTexture = this.GetComponent<GUITexture> ();
			StartCoroutine(GetStreetViewImage(latitude, longitude, zoom));
		}
		void Update(){
		}
		private IEnumerator GetStreetViewImage(double latitude, double longitude, double zoom) {
			while (true) {
				string url = "http://maps.googleapis.com/maps/api/streetview?size=" + width + "x" + height + "&location=" + latitude + "," + longitude + "&fov=" + zoom + "&heading=" + x + "&pitch=" + y + "&sensor=false";
				WWW www = new WWW (url);
				yield return www;
				mapGuiTexture.texture = www.texture;
				mapGuiTexture.color = new Color (mapGuiTexture.color.r, mapGuiTexture.color.g, mapGuiTexture.color.b, 1f);
				yield return new WaitForSeconds(5f);
			}
		}
	}