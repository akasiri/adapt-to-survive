using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {


	public void StartGame(){
		Application.LoadLevel (Scenes.Game);
	}

    public void Tutorial()
    {
        Application.LoadLevel(Scenes.Tutorial);
    }

	public void Quit(){
		Application.Quit ();
	}

}
