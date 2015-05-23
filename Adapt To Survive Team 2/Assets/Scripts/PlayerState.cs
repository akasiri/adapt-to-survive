using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public int animals = 1;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("1") && animals != 1) 
		{
			animals = 1;
			Debug.Log ("Monkey");
		}
		else if (Input.GetKeyDown ("2") && animals != 2)
		{
			animals = 2;
			Debug.Log ("Hawk");
		}
		else if (Input.GetKeyDown ("3") && animals != 3)
		{
			animals = 3;
			Debug.Log ("Dolphin");
		}
		else if (Input.GetKeyDown ("4") && animals != 4)
		{
			animals = 4;
			Debug.Log ("Bear");
		}
		else if (Input.GetKeyDown ("5") && animals != 5)
		{
			animals = 5;
			Debug.Log ("Mole");
		}
		else if (Input.GetKeyDown ("6") && animals != 6)
		{
			animals = 6;
			Debug.Log ("Porcupine");
		}
	}
}