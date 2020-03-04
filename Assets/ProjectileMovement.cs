using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    void Start()
    {
        CancelInvoke();
        InvokeRepeating("Move", 0f, .05f);

        StartCoroutine("CheckBounds");
    }

    void Move() {
        transform.position -= transform.right * Time.deltaTime * 60f;
    }

    IEnumerator CheckBounds(){

        if (transform.localPosition.x < -33f) {
            CancelInvoke();
            gameObject.SetActive(false);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

    }

}