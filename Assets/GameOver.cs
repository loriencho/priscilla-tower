using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject endCard;
    public GameObject over;
    public GameObject again;
    public ParticleSystem explosion;

    private SpriteRenderer sr;
    private SpriteRenderer sr2;
    private SpriteRenderer sr3;


    void Start()
    {
        explosion.Stop();
        endCard.SetActive(false);
        over.SetActive(false);
        again.SetActive(false);
        StartCoroutine("WaitForCollision");

        sr =  endCard.GetComponent<SpriteRenderer>(); 
        sr2 =  over.GetComponent<SpriteRenderer>(); 
        sr3 =  again.GetComponent<SpriteRenderer>(); 

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
        over.SetActive(true);
        again.SetActive(true);
        endCard.SetActive(true);
        float counter = 0;
        float duration = 1f;

        sr.color = new Color(188f, 136f, 84f, 0);
        sr2.color = new Color(0, 0, 0, 1);
        sr3.color = new Color(0, 0, 0, 1);

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1f, counter / duration);

            sr.color = new Color(188f/255f, 136f/255f, 84f/255f, alpha);
            sr2.color = new Color(1, 1, 1, alpha);
            sr3.color = new Color(1, 1, 1, alpha);


            yield return null;
        }
    }

    

    
}