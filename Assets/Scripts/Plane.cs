using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

    public float speed = 10;
    public float turnSpeed = 10;

    private Rigidbody2D rb2d;

    private Camera cam;

    private Vector2 mousePos;
    private Vector2 dir;

    void Start()
    {
        cam = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Rotate the plane towards mouse
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        dir = (mousePos - (Vector2)transform.position).normalized;
  
        transform.up = Vector2.Lerp(transform.up, dir, turnSpeed * Time.fixedDeltaTime);

        //Move plane forward
        rb2d.velocity = transform.up * speed;

    }

    public void Kill()
    {
        print("Oh no! we died :(");

        Application.LoadLevel(Application.loadedLevel);
    }

}
