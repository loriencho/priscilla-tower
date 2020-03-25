using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{


    void Start() {
        InvokeRepeating("Move", 0f, .03f);
    }
    void Move() {
        transform.position -= transform.right * Time.deltaTime * 45f;
        CheckBounds();
    }

    void CheckBounds(){

        if (transform.localPosition.x < -33f || transform.localPosition.x > 35f) {
            gameObject.SetActive(false);
        }
    }

}