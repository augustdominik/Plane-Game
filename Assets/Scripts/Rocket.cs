using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {


    public float speed = 10;
    public float turnSpeed = 10;

    private Rigidbody2D rb2d;

    private Vector2 dir;
    private Transform planeTransform;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        planeTransform = FindObjectOfType<Plane>().transform;
    }

    void FixedUpdate()
    {
        //Rotate towards plane
        dir = ((Vector2)planeTransform.position - (Vector2)transform.position).normalized;

        transform.up = Vector2.Lerp(transform.up, dir, turnSpeed * Time.fixedDeltaTime);

        //Move plane forward
        rb2d.velocity = transform.up * speed;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Plane")
        {
            col.GetComponent<Plane>().Kill();
        }

    }
}
