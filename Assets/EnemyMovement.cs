using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private ProjectilePools projectilePools;
    public float z;
    public float projectileWait;
        

    void Start()
    {
        projectilePools = ProjectilePools.Instance;

        InvokeRepeating("SpawnProjectile", 1.0f, projectileWait + Time.deltaTime);

        StartCoroutine("Waiter");
        


    }

    IEnumerator Waiter() {

        yield return new WaitForSeconds(3f);
        
        StartCoroutine("Move");



    }

    IEnumerator Move() {
        StartCoroutine("Rotate");
        while (gameObject.activeSelf)  {

            transform.position = new Vector3(transform.position.x -.5f - .5f * Time.deltaTime, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(projectileWait + Time.deltaTime);

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
        
        if (gameObject.activeSelf) {

            GameObject projectile;
            

            transform.position = new Vector3 (transform.position.x, transform.position.y, 10f);
            
            projectile = projectilePools.SpawnFromPool("EnemyProjectile", transform.position, Quaternion.Euler(0, 0, z));

            if (z > 360) {
                z += 30 + Time.deltaTime;
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
