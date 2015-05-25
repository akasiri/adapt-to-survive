using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {
	public Queue<GameObject> Obstacles;
	public int DifficultyIncreaseInterval = 15; //Seconds
	int DifficultyLevel = 0;
	public List<GameObject> Objects;
	public List<GameObject> SpawnedObjects;
	private float SpawnRate = 2f;
	int CurrentTime = 0;
	List<int> Lanes;

	void Start () {
		Obstacles = new Queue<GameObject> ();
		newQueue ();
		InvokeRepeating ("SpawnObstacle",1f, SpawnRate);
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
            
			SpawnRate *= 0.9f; 
			if(SpawnRate < 1.5f)
				SpawnRate = 1.5f;


			CancelInvoke("SpawnObstacle");

			InvokeRepeating ("SpawnObstacle",0.5f, SpawnRate);
		}
	}

	void DestroyObstacle(){
		SpawnedObjects.Remove (SpawnedObjects[0]);
		Destroy(SpawnedObjects[0]);
	}	

	void SpawnObstacle(){
		if (Obstacles.Count <= 3)
			newQueue ();
        int Objects = 0;
		int ObjectLimit;
		if(DifficultyLevel >= 4)
			ObjectLimit = 3;
		else
			ObjectLimit = DifficultyLevel >= 2 ? 2 : 1;
        
		List<int> LastPosition = new List<int>();
        while (Objects < ObjectLimit)
        {
            GameObject CurrentObstacle = Obstacles.Dequeue();
            int LanePos = Random.Range(0, 3);
            
			if (CurrentObstacle.tag == Tags.Tree)
                LanePos = Random.value < 0.5f ? 0 : 2;

            LanePos *= 2;

            if (CurrentObstacle.tag == "Bird")
                LanePos = 5;

			if(!LastPosition.Contains(LanePos)){
			    Vector3 newvec = new Vector3 (LanePos, 5, 0);
				GameObject newobj = (GameObject) Instantiate(CurrentObstacle, newvec, this.transform.rotation);
			    SpawnedObjects.Add (newobj);
			    Invoke ("DestroyObstacle", 10f);

			    Objects+=1;
			    LastPosition.Add(LanePos);
			}
		}
	}
}
