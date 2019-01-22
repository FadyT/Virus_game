using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f_player : MonoBehaviour
{

    public int speed;

    private Rigidbody2D rb;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal") , Input.GetAxisRaw("Vertical")) ;

        velocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
