using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform projectilePrefab;

    void Awake() {

        for (int i = 0; i < 10; i++) {
            Transform projectile = Instantiate(projectilePrefab);
            projectile.localPosition = Vector2.right * i;
        }
    }
}
