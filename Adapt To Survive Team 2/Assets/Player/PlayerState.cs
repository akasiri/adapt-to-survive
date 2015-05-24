using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public int animals = 1;
    private Animator theStateMachine;
    public GameObject tip;
	private float dolphinTimer;

	public AudioClip[] animalSounds;

    private AudioSource aud;
	private int i = 0;

    void Start()
    {
        aud = transform.Find("Audio").GetComponent<AudioSource>();
        Pause.staticUnPause();
        theStateMachine = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("1") && animals != 1 && !Pause.isPaused()) 

		{
			animals = 1;
			dolphinTimer = 0f;
			Debug.Log ("Monkey");
            theStateMachine.SetInteger(Parameters.State, 1);
            updateSpeed(4);
            aud.clip = animalSounds[0];
            aud.Play();
		}
		else if (Input.GetKeyDown ("2") && animals != 2 && !Pause.isPaused())
		{
			animals = 2;
			dolphinTimer = 0f;
			Debug.Log ("Hawk");
            theStateMachine.SetInteger(Parameters.State, 2);
            updateSpeed(3.5f);

            aud.clip = animalSounds[1];
            aud.Play();
		}
		else if (Input.GetKeyDown ("3") && animals != 3 && !Pause.isPaused())
		{
			animals = 3;

			dolphinTimer = 2f;

			Debug.Log ("Dolphin");
            theStateMachine.SetInteger(Parameters.State, 3);
            updateSpeed(3f);

            aud.clip = animalSounds[2];
            aud.Play();
		}
		else if (Input.GetKeyDown ("4") && animals != 4 && !Pause.isPaused())
		{
			animals = 4;
			dolphinTimer = 0f;
			Debug.Log ("Bear");
            theStateMachine.SetInteger(Parameters.State, 4);
            updateSpeed(4);

            aud.clip = animalSounds[3];
            aud.Play();
		}
		else if (Input.GetKeyDown ("5") && animals != 5 && !Pause.isPaused())
		{
			animals = 5;
			dolphinTimer = 0f;;
			Debug.Log ("Mole");
            theStateMachine.SetInteger(Parameters.State, 5);
            updateSpeed(3.5f);

            aud.clip = animalSounds[4];
            aud.Play();
		}
		else if (Input.GetKeyDown ("6") && animals != 6 && !Pause.isPaused())
		{
			animals = 6;
			dolphinTimer = 0f;
			Debug.Log ("Porcupine");
            theStateMachine.SetInteger(Parameters.State, 6);
            updateSpeed(4);

            aud.clip = animalSounds[5];
            aud.Play();
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