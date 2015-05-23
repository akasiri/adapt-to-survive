using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	public void RestartLevel () {
        GetComponent<Pause>().unPause();
        Application.LoadLevel(Application.loadedLevel);
	}
}
