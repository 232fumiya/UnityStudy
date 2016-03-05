using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LifeGage : MonoBehaviour {
	private Image image1;
	public int startLife=10;
	public static int life;
	// Use this for initialization
	void Start () {
		image1=this.GetComponent<Image> ();
		life=startLife;
	}
	
	// Update is called once per frame
	void Update () {
	//lifeが減ると、ゲージが縮む
		image1.fillAmount = life / startLife;
	}
}
