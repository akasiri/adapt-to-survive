using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour 
{
	public float speed = 3f;
	public int objectWeakness = 1;

    void Start()
    {
        //temp code
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed, 0);
    }

	void Update()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed, 0);
		setObjectWeakness();
	}

	void setObjectWeakness()
	{
		switch (gameObject.tag) {
		case "Tree":
			objectWeakness = 1;
			break;
		case "Pitfall":
			objectWeakness = 2;
			break;
		case "Water":
			objectWeakness = 3;
			break;
		case "Boulder":
			objectWeakness = 4;
			break;
		case "Fire":
			objectWeakness = 5;
			break;
		case "Predator":
			objectWeakness = 6;
			break;
		}
	}

	/*
	 * fallen tree = 1
	 * pitfalls, large gap = 2
	 * water = 3
	 * boulders = 4
	 * fire = 5
	 * predators = 6
	 */
	void OnTriggerEnter2D(Collider2D coll) 
	{
        Debug.Log("Hit!");
		if (coll.gameObject.tag == "Player") 
		{
            if (coll.gameObject.GetComponent<PlayerState>().animals != objectWeakness)
            {
                // player die
                coll.gameObject.GetComponent<PlayerDeath>().Die();
            }
            else
            {
                OnDestroy();
            }
		}
	}

    protected virtual void OnDestroy()
    {
    }
}