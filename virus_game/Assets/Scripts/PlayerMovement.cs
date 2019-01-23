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
        velocity /= 300*Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -speed;
            //transform.localScale = new Vector3(-1, 1, 1);
            rotation.y = 180;
            //transform.localScale = new Vector3( transform.localScale.x *2 , transform.localScale.y , transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = speed;
            rotation.y = 0;
            //transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y, transform.localScale.z);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity.y = -speed;
            //transform.localScale = new Vector3(-1, 1, 1);
            //rotation.x = 180;
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y *2, transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y = speed;
            //rotation.x = 0;
          //  transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y *2 , transform.localScale.z);

        }
        body.velocity = velocity;

        transform.rotation = Quaternion.Euler(rotation);
        /*
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        */
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
                powerBarScript.power += 10;
                Debug.Log("enemy " + HealthBar.health);
                Destroy(collision.gameObject);
                break;

            case "Heart":
                Debug.Log("collision heart ");
                if (HealthBar.health < 100)
                {
                    HealthBar.health += 10;
                    Debug.Log("enemy " + HealthBar.health);
                    Destroy(collision.gameObject);
                }
                break;


            case "collectable":
                Debug.Log("collision collectable ");
                scoreScript.score += 10;
                Destroy(collision.gameObject);
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
