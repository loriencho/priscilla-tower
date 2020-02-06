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
        Vector2 scale = Vector2.one * 19/size;
        Vector2 position;

        position.y = 0f;
        projectiles = new Transform[size];

        for (int i = 1; i < size; i += .2) {
            Transform projectile = Instantiate(projectilePrefab);
            position.x = i;
            projectile.localScale = scale;
            projectile.SetParent(transform, false);

            projectiles[i] = projectile;

        }

    }

    void Update() {

        float b = Mathf.PingPong(Time.time, 10);
        for (int i = 0; i < projectiles.Length; i++) {
            Transform projectile = projectiles[i];
            Vector3 position = projectile.localPosition;
            position.y = position.x*b*(Mathf.Cos(position.x + b) - Mathf.Sin(position.x + b));
            projectile.localPosition = position;

        }
    }
}
