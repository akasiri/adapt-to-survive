using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {
	public Queue<GameObject> Obstacles;
	public int DifficultyIncreaseInterval = 20; //Seconds
	public List<GameObject> Objects;
	public float SpawnRate = 3f;
	int CurrentTime = 0;
	List<int> Lanes;
	void Start () {
		Obstacles = new Queue<GameObject> ();
		newQueue ();
		InvokeRepeating ("SpawnObstacle",2f, SpawnRate);
		InvokeRepeating ("TimeControl",0f, 1f);
	}

	void newQueue(){
		for (int i=0; i<10; i++) {
			int index = Random.Range(0,(Objects.Count-1));
			Obstacles.Enqueue(Objects[index]);
		}
	}

	void TimeControl(){
		CurrentTime += 1;
		if(CurrentTime >= DifficultyIncreaseInterval){
			CurrentTime = 0;
			SpawnRate *= 0.8f;
			Debug.Log("harder");
			CancelInvoke("SpawnObstacle");
			InvokeRepeating ("SpawnObstacle",0f, SpawnRate);
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
