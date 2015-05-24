using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Obstacle : MonoBehaviour 
{
	public static float speed = 3f;
    [HideInInspector]
	public int objectWeakness = 1;
    public GameObject tip;
    void Start()
    {
        //temp code
		GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed, 0);
        setObjectWeakness();
    }

	protected void setObjectWeakness()
	{
		switch (gameObject.tag) 
		{
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
        Debug.Log(this.tag);
		if (coll.gameObject.tag == "Player") 
		{
            if (coll.gameObject.GetComponent<PlayerState>().animals != objectWeakness)
            {
                // player die
                coll.gameObject.GetComponent<PlayerDeath>().Die(tip);
            }
            else
            {
                ScoreScript.AddPoints(5, this.tag);
                OnDestroy();
                
            }
		}
	}
	protected virtual void OnDestroy(){
	}
}