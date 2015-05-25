using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public int animals = 1;
    private Animator theStateMachine;
    public GameObject tip;
	private float dolphinTimer;

    private ParticleSystem change;
	public AudioClip[] animalSounds;

    private AudioSource aud;
	private int i = 0;

    void Start()
    {
        change = transform.Find("SpawnEffect").GetComponent<ParticleSystem>();
        aud = transform.Find("Audio").GetComponent<AudioSource>();
        Pause.staticUnPause();
        theStateMachine = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		if ((Input.GetKeyDown ("1") || Input.GetKeyDown("[1]")) && animals != 1 && !Pause.isPaused()) 

		{
            OnChange(1);

			dolphinTimer = 0f;
			Debug.Log ("Monkey");

            updateSpeed(3.5f);
		}
		else if ((Input.GetKeyDown ("2") || Input.GetKeyDown("[2]")) && animals != 2 && !Pause.isPaused())
		{
            OnChange(2);
			dolphinTimer = 0f;
			Debug.Log ("Hawk");
            updateSpeed(3.5f);

		}
		else if ((Input.GetKeyDown ("3") || Input.GetKeyDown ("[3]")) && animals != 3 && !Pause.isPaused())
		{
            OnChange(3);

			dolphinTimer = 2f;

			Debug.Log ("Dolphin");

            updateSpeed(3f);
		}
		else if ((Input.GetKeyDown ("4") || Input.GetKeyDown ("[4]")) && animals != 4 && !Pause.isPaused())
		{
            OnChange(4);

            updateSpeed(4f);

			dolphinTimer = 0f;
			Debug.Log ("Bear");

		}
		else if ((Input.GetKeyDown ("5") || Input.GetKeyDown ("[5]")) && animals != 5 && !Pause.isPaused())
		{
            OnChange(5);
			dolphinTimer = 0f;;
			Debug.Log ("Mole");
            updateSpeed(3.5f);
		}
		else if ((Input.GetKeyDown ("6") || Input.GetKeyDown ("[6]")) && animals != 6 && !Pause.isPaused())
		{
            OnChange(6);

			dolphinTimer = 0f;
			Debug.Log ("Porcupine");
            
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

    void OnChange(int index)
    {
        InputsTutorial.setActive(index);
        theStateMachine.SetInteger(Parameters.State, index);
        animals = index;
        change.Play();
        aud.clip = animalSounds[index - 1];
        aud.Play();
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