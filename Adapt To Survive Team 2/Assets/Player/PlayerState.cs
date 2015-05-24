using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public int animals = 1;
    private Animator theStateMachine;
    public GameObject tip;
	private float dolphinTimer;

    void Start()
    {
        Pause.staticUnPause();
        theStateMachine = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("1") && animals != 1) 
		{
			animals = 1;
			dolphinTimer = 0f;
			Debug.Log ("Monkey");
            theStateMachine.SetInteger(Parameters.State, 1);
            updateSpeed(4);
		}
		else if (Input.GetKeyDown ("2") && animals != 2)
		{
			animals = 2;
			dolphinTimer = 0f;
			Debug.Log ("Hawk");
            theStateMachine.SetInteger(Parameters.State, 2);
            updateSpeed(3.5f);
		}
		else if (Input.GetKeyDown ("3") && animals != 3)
		{
			animals = 3;

			dolphinTimer = 2f;

			Debug.Log ("Dolphin");
            theStateMachine.SetInteger(Parameters.State, 3);
            updateSpeed(3f);
		}
		else if (Input.GetKeyDown ("4") && animals != 4)
		{
			animals = 4;
			dolphinTimer = 0f;
			Debug.Log ("Bear");
            theStateMachine.SetInteger(Parameters.State, 4);
            updateSpeed(4);
		}
		else if (Input.GetKeyDown ("5") && animals != 5)
		{
			animals = 5;
			dolphinTimer = 0f;;
			Debug.Log ("Mole");
            theStateMachine.SetInteger(Parameters.State, 5);
            updateSpeed(3.5f);

		}
		else if (Input.GetKeyDown ("6") && animals != 6)
		{
			animals = 6;
			dolphinTimer = 0f;
			Debug.Log ("Porcupine");
            theStateMachine.SetInteger(Parameters.State, 6);
            updateSpeed(4);
		}

		if (dolphinTimer > 0) {
			dolphinTimer -= Time.deltaTime;
		}

        if (dolphinTimer < 0)
        {
            this.gameObject.GetComponent<PlayerDeath>().Die(tip);
            dolphinTimer = 0;
        }
	}

    void updateSpeed(float speed)
    {
        Obstacle.speed = speed;
        foreach (string tag in Tags.Obstacles)
        {
            foreach (GameObject obstacles in GameObject.FindGameObjectsWithTag(tag))
            {
                obstacles.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed, 0);
            }
        }
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Water") {
			dolphinTimer = 0;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Water") {
			dolphinTimer = 2f;
		}
	}
}