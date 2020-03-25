using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject endCard;
    public ParticleSystem explosion;

    private SpriteRenderer sr;

    void Start()
    {
        explosion.Stop();
        endCard.SetActive(false);
        StartCoroutine("WaitForCollision");

        sr =  endCard.GetComponent<SpriteRenderer>(); 
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);

        endCard.transform.localPosition = new Vector3(endCard.transform.localPosition.x, 123f, endCard.transform.localPosition.z);

    }

    IEnumerator WaitForCollision(){
        LayerMask layerMask = LayerMask.GetMask("Projectiles");

        while ( !(Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1.15f, layerMask, 10f, 10f))) {
            yield return null;

        }        
        explosion.transform.position = transform.position;
        explosion.Play();

        yield return new WaitForSeconds(.5f);
        explosion.Stop();

        StartCoroutine("SlideIntoPlace");
        StartCoroutine("fadeIn");

    }

    IEnumerator SlideIntoPlace() {
        float timeSinceStarted = 0f;
        endCard.SetActive(true);

        while (endCard.transform.position != Vector3.zero) {
                
            timeSinceStarted += Time.deltaTime;
            endCard.transform.position = Vector3.Lerp(endCard.transform.position, Vector3.zero, timeSinceStarted);
            yield return null;
        }
    }

    IEnumerator fadeIn()
    {
        endCard.SetActive(true);
        float counter = 0;
        int duration = 1;

        Color spriteColor = sr.material.color;
        sr.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 0);

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, counter / duration);

            sr.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            yield return null;
        }
    }

    

    
}