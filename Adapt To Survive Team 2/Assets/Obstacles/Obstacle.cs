using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    void Start()
    {
        //temp code
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -3, 0);
    }

	public int weakness = 1;
	void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("Hit!");
		if (coll.gameObject.tag == "Player") {
			if (coll.gameObject.GetComponent<PlayerState>().animal == weakness) {
				// obstacle die
                OnDestroy();
			}
			else {
				// player die
			}
		}
	}

    protected virtual void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
