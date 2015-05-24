using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
	GameObject Spawner;
	public int animals = 1;
    private Animator theStateMachine;
	public float currentSpeed = -3;
	// Update is called once per frame

    void Start()
    {
		Spawner = GameObject.Find ("Spawner");

        theStateMachine = GetComponent<Animator>();
    }
	void Update () 
	{
		currentSpeed = -3;
		if (Input.GetKeyDown ("1") && animals != 1) 
		{
			animals = 1;
			currentSpeed = 0;
			Debug.Log ("Monkey");
            theStateMachine.SetInteger(Parameters.State, 1);
		}
		else if (Input.GetKeyDown ("2") && animals != 2)
		{
			animals = 2;
			Debug.Log ("Hawk");
            theStateMachine.SetInteger(Parameters.State, 2);
		}
		else if (Input.GetKeyDown ("3") && animals != 3)
		{
			animals = 3;
			Debug.Log ("Dolphin");
            theStateMachine.SetInteger(Parameters.State, 3);
		}
		else if (Input.GetKeyDown ("4") && animals != 4)
		{
			animals = 4;
			currentSpeed = -2.5f;
			Debug.Log ("Bear");
            theStateMachine.SetInteger(Parameters.State, 4);
		}
		else if (Input.GetKeyDown ("5") && animals != 5)
		{
			animals = 5;
			Debug.Log ("Mole");
            theStateMachine.SetInteger(Parameters.State, 5);
		}
		else if (Input.GetKeyDown ("6") && animals != 6)
		{
			animals = 6;
			currentSpeed = -1.5f;
			Debug.Log ("Porcupine");
            theStateMachine.SetInteger(Parameters.State, 6);
		}

		Spawner.GetComponent<SpawnScript>().ChangeSpeed(currentSpeed);
	}

}