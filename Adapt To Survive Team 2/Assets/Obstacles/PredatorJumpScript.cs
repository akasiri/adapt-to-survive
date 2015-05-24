using UnityEngine;
using System.Collections;

public class PredatorJumpScript : MonoBehaviour {
    private bool jumped = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(Tags.Player) || jumped)
            return;
        GetComponent<AudioSource>().Play();
        transform.parent.Find("SpeedParticles").GetComponent<ParticleSystem>().Play();
        jumped = true;
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        Rigidbody2D rigid = transform.parent.GetComponent<Rigidbody2D>();
        Vector3 newSpeed = rigid.velocity * 3;
        rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.25f);
        Pause.Freeze(0.2f, 0.4f);
        rigid.velocity = newSpeed;
    }

}
