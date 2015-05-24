﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {
	public Queue<GameObject> Obstacles;
	public int DifficultyIncreaseInterval = 20; //Seconds
	public List<GameObject> Objects;
	public List<GameObject> SpawnedObjects;
	public float SpawnRate = 3f;
	int CurrentTime = 0;
	List<int> Lanes;

	void Start () {
		Obstacles = new Queue<GameObject> ();
		newQueue ();
		InvokeRepeating ("SpawnObstacle",2f, SpawnRate);
		InvokeRepeating ("TimeControl",0f, 1f);
	}

	void newQueue()
	{
		int index;
		for (int i = 0; i < 10; i++) 
		{
			index = Random.Range(0,Objects.Count);
			Obstacles.Enqueue(Objects[index]);
            Debug.Log(Objects[index]);
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

	void DestroyObstacle(){
		SpawnedObjects.Remove (SpawnedObjects[0]);
		Destroy (SpawnedObjects[0]);
	}

//	public void ChangeSpeed(float newspeed){
//		for (int i =0; i< SpawnedObjects.Count; i++) {
//			if(SpawnedObjects[i])
//				SpawnedObjects[i].GetComponent<Obstacle>().speed = newspeed;
//		}
//	}

	void SpawnObstacle(){
		Vector3 newvec = new Vector3 (Random.Range (0, 3)*2, 5, 0);
		GameObject newobj = (GameObject) Instantiate (Obstacles.Dequeue(), newvec, this.transform.rotation);
		//float obj_speed = GameObject.Find("Player").GetComponent<PlayerState>().currentSpeed;
		//newobj.GetComponent<Obstacle> ().speed = obj_speed;
		SpawnedObjects.Add (newobj);
		Invoke ("DestroyObstacle", 5f);
		if (Obstacles.Count <= 0)
			newQueue ();
	}
}
