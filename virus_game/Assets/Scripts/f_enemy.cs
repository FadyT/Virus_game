using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f_enemy : MonoBehaviour
{
    public float speed = 3 ;
    GameObject target;

    private bool isDetected = false;
    private void Start()
    {
        target = PlayerMovement.myPlayer;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.GetComponent<Transform>().position, transform.position) < 3)
        {
            isDetected = true;
        }
        if(target != null && isDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.GetComponent<Transform>().position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            Destroy(gameObject);

        }

    }

}
