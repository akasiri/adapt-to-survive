using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public string scene = "DerekCopy";

	// Use this for initialization
	public void RestartLevel () {
		Application.LoadLevel (scene);
	}
}
