using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //Speed of Player
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject hitEffect; 
    Vector2 movement; 
    Vector2 mousePos;

    public string h;
    public string v;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw(h);
        movement.y = Input.GetAxisRaw(v);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    
        Vector2 lookDir = mousePos - rb.position; //gets direction from player to mouse
        float angle = Mathf.Atan2(lookDir.y , lookDir.x) * Mathf.Rad2Deg - 90f; //remove the 90 if he is rotated 90 degrees too far in one direction, this was just from the tutorial i was using 
        rb.rotation = angle;
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}
