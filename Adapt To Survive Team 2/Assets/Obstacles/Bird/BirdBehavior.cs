using UnityEngine;
using System.Collections;

public class BirdBehavior : MonoBehaviour {

    public GameObject background;
    public float speed = 2.0f;

    private Animator birdAnimator;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        birdAnimator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -(0.5f * 3.2f), 0);

//        birdAnimator.SetInteger("currentAction", Random.Range(1, 4));
//        StartCoroutine(DoUpdate());
	}

    void FixedUpdate() {
        int rand = Random.Range(1, 100);

        if (rand < 1)
        {
            birdAnimator.SetInteger("currentAction", 0);
        }
        else if (rand < 3)
        {
            birdAnimator.SetInteger("currentAction", 1);
        }
        else if (rand < 5)
        {
            birdAnimator.SetInteger("currentAction", 2);
        }
        else if (rand < 7)
        {
            birdAnimator.SetInteger("currentAction", 3);
        }
        else if (rand < 9)
        {
            birdAnimator.SetInteger("currentAction", 4);
        }
        
        int currentAction = birdAnimator.GetInteger("currentAction");
        if (currentAction == 1)
        {
            this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (currentAction == 2)
        {
            this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (currentAction == 3)
        {
            this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (currentAction == 4)
        {
            this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0, speed * Time.deltaTime, 0);
        }
//    }
	
	// Update is called once per frame
//	IEnumerator DoUpdate () {
//        while (true)
//        {

//            yield return new WaitForSeconds(1f);
//        }
    }
}