using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{

    public float speed;
    public float TimetoLive;
    void Start()
    {
        Destroy(gameObject, TimetoLive);

    }

    void Update()
    {
        transform.Translate(Vector3.down * -1 * speed * Time.deltaTime);

    }
}

