using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpForce;
    public int maxSpeed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < maxSpeed){
            if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpForce);
            }
        }
        
    }
}
