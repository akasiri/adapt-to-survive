using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
	public GameObject Canvas, Canvas2;



	public void SecondPage(){
		Canvas.gameObject.SetActive (false);
		Canvas2.gameObject.SetActive (true);
	}

	public void FirstPage(){
		Canvas.gameObject.SetActive (true);
		Canvas2.gameObject.SetActive (false);
	}


	public void MainMenu(){
		Application.LoadLevel ("Menu");
	}
}
