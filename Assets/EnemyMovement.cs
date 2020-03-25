using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private ProjectilePools projectilePools;
    public int min;
    public int max;
    public int clockwise;

    public float pause;
    public float projectileWait;

    public int start;
    public int increment;
    public int amt;

    private float z;
    private int mode = 0;

        

    void Start()
    {
        projectilePools = ProjectilePools.Instance;

        z = min;
        InvokeRepeating("SpawnProjectile", 1.0f, projectileWait);

        StartCoroutine("Waiter");
        


    }

    IEnumerator Waiter() {

        yield return new WaitForSeconds(pause);
        
        StartCoroutine("Move");



    }

    IEnumerator Move() {
        StartCoroutine("Rotate");
        while (gameObject.activeSelf)  {

            transform.position = new Vector3(transform.position.x -.5f - .5f * Time.deltaTime, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(.05f);

        }
        yield return null;
    }

    IEnumerator Rotate() {

        while(gameObject.activeSelf) {

            transform.Rotate(0, 0, 1  + Time.deltaTime);
            yield return null;
        }
    }

    void SpawnProjectile() {

        if (min == 361) {
            mode = 2;
        }
        if (gameObject.activeSelf) {

            GameObject projectile;
            

            transform.position = new Vector3 (transform.position.x, transform.position.y, 10f);

            if (min != max ){
                z += (20 + Time.deltaTime) * clockwise;
                if (mode == 1) {
                    z -= (40 + Time.deltaTime) * clockwise;
                }

                if (z >= max && mode == 0) {
                    mode = 1;
                }

                else if (z <= min && mode == 1) {
                    mode = 0;
                }
            }
            else {
                z = min;
            }


            for (int i = 0; i < amt; i++ ) {
                projectile = projectilePools.SpawnFromPool("EnemyProjectile", transform.position, Quaternion.Euler(0, 0, start + increment * i + z));
                
            }   
                
            


        }
        else {
            CancelInvoke();
        }



    }

    void OnBecameInvisible()
    {
        enabled = false;
        gameObject.SetActive(false);
    }
}
