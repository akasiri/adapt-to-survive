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
//        birdAnimator.SetInteger("currentAction", Random.Range(1, 4));
        StartCoroutine(DoUpdate());
	}

    void FixedUpdate() {

//        rigidBody.velocity = new Vector2(0, -(background.GetComponent<BackgroundScript>().speed * 3.2f));
        
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
    }
	
	// Update is called once per frame
	IEnumerator DoUpdate () {
        while (true)
        {
            int rand = Random.Range(1, 100);

            if (5 > rand)
            {
                birdAnimator.SetInteger("currentAction", 0);
            }
            else if (20 > rand)
            {
                birdAnimator.SetInteger("currentAction", 1);
            }
            else if (35 > rand)
            {
                birdAnimator.SetInteger("currentAction", 2);
            }
            else if (50 > rand)
            {
                birdAnimator.SetInteger("currentAction", 3);
            }
            else if (65 > rand)
            {
                birdAnimator.SetInteger("currentAction", 4);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}