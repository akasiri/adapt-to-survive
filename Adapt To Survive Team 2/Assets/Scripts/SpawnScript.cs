using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {
	public Queue<GameObject> Obstacles;
	public int DifficultyIncreaseInterval = 20; //Seconds
	int DifficultyLevel = 0;
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
		}
	}

	void TimeControl(){

		CurrentTime += 1;

		if(CurrentTime >= DifficultyIncreaseInterval){
			CurrentTime = 0;
			DifficultyLevel += 1;
            
            SpawnRate = SpawnRate *= 0.8f < 1 ? 1 : SpawnRate *= 0.8f;

			CancelInvoke("SpawnObstacle");

			InvokeRepeating ("SpawnObstacle",0f, SpawnRate);
		}
	}

	void DestroyObstacle(){
		SpawnedObjects.Remove (SpawnedObjects[0]);
		Destroy (SpawnedObjects[0]);
	}	

	void SpawnObstacle(){
        int Objects = 0;
        int ObjectLimit = DifficultyLevel >= 2 ? 2 : 1;
		List<int> LastPosition = new List<int>();
        while (Objects < ObjectLimit)
        {
			int LanePos = Random.Range (0, 3) * 2;
			if(!LastPosition.Contains(LanePos)){
			    Vector3 newvec = new Vector3 (LanePos, 5, 0);
			    GameObject newobj = (GameObject)Instantiate (Obstacles.Dequeue (), newvec, this.transform.rotation);
			    SpawnedObjects.Add (newobj);
			    Invoke ("DestroyObstacle", 5f);
			
			    if (Obstacles.Count < 2)
				    newQueue ();

			    Objects+=1;
			    LastPosition.Add(LanePos);
			}
		}
	}
}
