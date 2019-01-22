using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    Rigidbody2D body;
    Vector3 velocity;
    Vector3 rotation;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        velocity = new Vector3();
        rotation = new Vector3();
    }
    // Update is called once per frame
    void Update()
    {
        velocity /= 10;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -speed;
            //transform.localScale = new Vector3(-1, 1, 1);
            rotation.y = 180;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = speed;
            rotation.y = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity.y = -speed;
            //transform.localScale = new Vector3(-1, 1, 1);
            //rotation.x = 180;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y = speed;
            //rotation.x = 0;

        }
        body.velocity = velocity;

        transform.rotation = Quaternion.Euler(rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision enter ");

    }
}
