using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public int animals = 1;
    private Animator theStateMachine;
	// Update is called once per frame

    void Start()
    {


        theStateMachine = GetComponent<Animator>();
    }
	void Update () 
	{

		if (Input.GetKeyDown ("1") && animals != 1) 
		{
			animals = 1;

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
			Debug.Log ("Porcupine");
            theStateMachine.SetInteger(Parameters.State, 6);
		}
	}

}