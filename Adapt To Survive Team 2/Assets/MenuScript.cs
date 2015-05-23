using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {


	public void StartGame(){
		Application.LoadLevel ("MainGamePlay");
	}

	
	public void Credits(){
		Application.LoadLevel ("Credits");
	}

	
	public void Quit(){
		Application.Quit ();
	}

}
