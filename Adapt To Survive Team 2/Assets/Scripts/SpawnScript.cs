using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {
	public Queue<GameObject> Obstacles;
	public List<GameObject> Objects;
	public float SpawnRate = 3f;
	List<int> Lanes;
	void Start () {
		Obstacles = new Queue<GameObject> ();
		newQueue ();
		InvokeRepeating ("SpawnObstacle",2f, SpawnRate);
	}

	void newQueue(){
		for (int i=0; i<10; i++) {
			int index = Random.Range(0,(Objects.Count-1));
			Obstacles.Enqueue(Objects[index]);
		}
	}


	void SpawnObstacle(){
		Vector3 newvec = new Vector3 (Random.Range (0, 2)*2, 5, 0);
		GameObject newobj = (GameObject) Instantiate (Obstacles.Dequeue(), newvec, this.transform.rotation);
		Destroy (newobj, 5f);
		if (Obstacles.Count <= 2)
			newQueue ();
	}
}
