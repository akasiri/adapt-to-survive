using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	
	public int weakness = 1;
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Player") {
			if (coll.gameObject.GetComponent<PlayerState>().animals == weakness) {
				// obstacle die
				this.gameObject.SetActive(false);
			}
			else {
				// player die
			}
		}
	}

}
