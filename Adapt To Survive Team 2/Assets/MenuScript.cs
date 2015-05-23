using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {


	public void StartGame(){
		Application.LoadLevel ("ActualDerek");
	}

	
	public void Credits(){
		Application.LoadLevel ("Credits");
	}

	
	public void Quit(){
		Application.Quit ();
	}

}
