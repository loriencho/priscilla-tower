using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform projectilePrefab;
    private Transform[] projectiles;
    [Range(0, 100)]
    public int size;
    [Range(-17, 17)]
    public float horizontal;
    [Range(0, 50)]
    public float y;




    void Awake() {
        Vector2 scale = Vector2.one * .5f;
        Vector2 position;

        position.y = 0f;
        projectiles = new Transform[size];

        for (int i = 0; i < size; i += 1) {
            Transform projectile = Instantiate(projectilePrefab);
            position.x = i/5;
            projectile.localScale = scale;
            projectile.SetParent(transform, false);
            projectile.localPosition = position;

            projectiles[i] = projectile;
        }

    }

    void Update() {

        float c = Mathf.PingPong(Time.time, 4);
        float b = 2f - c;
        for (int i = 0; i < size; i++) {
            Transform projectile = projectiles[i];
            Vector3 position = projectile.localPosition;
            float a = i/5;
            position.x = (a*b*(Mathf.Cos(a+b))-Mathf.Sin(a+b));
            position.y = a*b;
            projectile.localPosition = position;

        }
    }
}
