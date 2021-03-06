﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private ProjectilePools projectilePools;
    private int direction = 180;

    void Start( ){

        projectilePools = ProjectilePools.Instance;
        StartCoroutine("Shoot");

    }
    // Update is called once per frame

    IEnumerator Shoot() {
        while(true) {
            if (Input.GetKey("space")) {

            GameObject projectile;

                transform.position = new Vector3 (transform.position.x, transform.position.y, 10f);
                Quaternion rotation = Quaternion.Euler(0, 0, direction);
                
                projectile = projectilePools.SpawnFromPool("PlayerProjectile", transform.position, rotation);



            }
            yield return new WaitForSeconds(.2f);
                

            

        }
    }


    void Update()
    {
        if (Input.GetKey("up")) {
            if (!(transform.position.y >= 13f)) {
                transform.position = new Vector3(transform.position.x, transform.position.y + .25f + Time.deltaTime, -2f);
            }
        }

        if (Input.GetKey("down")) {
            if (!(transform.position.y <= -13f)) {
                transform.position = new Vector3(transform.position.x, transform.position.y - .25f - Time.deltaTime,-2f);
            }
        }

        if (Input.GetKey("right")) {
            if (!(transform.position.x >= 25f)) {
                transform.position = new Vector3(transform.position.x + .25f + Time.deltaTime, transform.position.y,-2f);
            }

        }

        if (Input.GetKey("left")) {
            if (!(transform.position.x <= -25f)) {
                transform.position = new Vector3(transform.position.x - .25f - Time.deltaTime, transform.position.y,-2f);
         }
        }


        if (Input.GetKey("a")) {
            direction -= 90;
        }

        if (Input.GetKey("d")) {
            direction += 90;
        }

    }
}
