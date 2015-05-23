using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour 
{
	public int objectWeakness = 1;

    void Start()
    {
        //temp code
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -3, 0);
    }

	void Update()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector3(0, -3, 0);
		setObjectWeakness();
	}

	void setObjectWeakness()
	{
		if (gameObject.name == "Tree(Clone)")
			objectWeakness = 1;
		else if (gameObject.name == "Pitfall(Clone)")
			objectWeakness = 2;
		else if (gameObject.name == "Water(Clone)")
			objectWeakness = 3;
		else if (gameObject.name == "Boulder(Clone)")
			objectWeakness = 4;
		else if (gameObject.name == "Fire(Clone)")
			objectWeakness = 5;
		else //if (gameObject.name == "Predator(Clone)")
			objectWeakness = 6;
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
			if (coll.gameObject.GetComponent<PlayerState>().animals == objectWeakness) 
			{
				// obstacle die
                OnDestroy();
			}
			else 
			{
				// player die
				coll.gameObject.GetComponent<PlayerDeath>().Die();
			}
		}
	}

    protected virtual void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}