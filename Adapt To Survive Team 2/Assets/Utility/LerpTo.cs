using UnityEngine;
using System.Collections;

public class LerpTo : MonoBehaviour {
    private IEnumerator lerp;
    public void DoLerpTo(Vector3 position, float dampening = 0.3f, bool local = true)
    {
        if (lerp != null)
        {
            StopCoroutine(lerp);
        }
        if (local)
            lerp = LerpLocal(position, dampening);
        else
            lerp = LerpGlobal(position, dampening);
        StartCoroutine(lerp);
    }

    private IEnumerator LerpGlobal(Vector3 position, float dampening)
    {
        Vector3 distance = transform.position - position;
        while (distance.magnitude > 0.1)
        {
            transform.position -= dampening * distance;
            distance = transform.position - position;
            yield return 0;
        }
        transform.position = position;
    }

    private IEnumerator LerpLocal(Vector3 position, float dampening)
    {
        Vector3 distance = transform.localPosition - position;
        while (distance.magnitude > 0.1)
        {
            transform.localPosition -= dampening * distance;
            distance = transform.localPosition - position;
            yield return 0;
        }
        transform.localPosition = position;
    }
}
