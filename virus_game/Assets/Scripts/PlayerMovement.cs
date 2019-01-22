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
        body.velocity /= 10;
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
        body.velocity = velocity;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity.y = -speed;
            //transform.localScale = new Vector3(-1, 1, 1);
            rotation.x = 180;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y = speed;
            rotation.x = 0;

        }
        transform.rotation = Quaternion.Euler(rotation);
    }
}
