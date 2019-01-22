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
    public static GameObject myPlayer;
    void Awake ()
    {
        myPlayer = gameObject;
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
        switch (collision.gameObject.name)
        {
            case "enemy":
                Debug.Log("collision enemy ");
                Destroy(this.gameObject);
                HealthBar.health = 0;
                break;

            case "Enemy2":
                Debug.Log("collision enemy2 ");
                HealthBar.health -= 10;
                Debug.Log("enemy " + HealthBar.health);
                Destroy(collision.gameObject);
                break;

            case "Heart":
                Debug.Log("collision heart ");
                if (HealthBar.health <100)
                {
                    HealthBar.health += 10;
                    Debug.Log("enemy " + HealthBar.health);
                    Destroy(collision.gameObject);
                }
                break;


            default:
                Debug.Log("collision " + collision.gameObject.name);
                break;
        }

    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.name)
        {
            case "Enemy":
                Debug.Log("collision enemy ");
                break;

            case "Enemy2":
                Debug.Log("collision enemy2 ");
                HealthBar.health -= 10;
                Debug.Log("enemy " + HealthBar.health);
                Destroy(collision.gameObject);
                break;

            case "Heart":
                Debug.Log("collision heart ");
                HealthBar.health += 10;
                Debug.Log("enemy " + HealthBar.health);
                break;


            default:
                Debug.Log("collision " + collision.gameObject.name);
                break;
        }
        
    }
*/
}
