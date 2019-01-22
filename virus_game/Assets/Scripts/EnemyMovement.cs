using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Welcome Ahmed (:
    public Transform PathHolder;
    public float speed = 5, distance = 18;
    public float waitTime = .3f, turnSpeed;
    int x;
    int targetWayPointIndex;
    Vector3 targetWayPoint, dirToLookTarget;
    float turnAngle, angle, counter;
    public GameObject bullet;
    Vector3[] wayPoints;
    int isPlayerDetected;//0 No 1 Yes -1 Return
    void Start()
    {
        wayPoints = new Vector3[PathHolder.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = PathHolder.GetChild(i).position;
            wayPoints[i] = new Vector3(wayPoints[i].x, wayPoints[i].y, transform.position.z);
        }
        transform.position = wayPoints[0];
        targetWayPointIndex = 1;
        targetWayPoint = wayPoints[targetWayPointIndex];
        StartCoroutine(FollowPath());
    }
    IEnumerator FollowPath()
    {
        //print("ok");
        //transform.LookAt(targetWayPoint);
        //print(transform.eulerAngles);
        while (true)
        {
            counter += Time.deltaTime;
            if (isPlayerDetected == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetWayPoint, speed * Time.deltaTime);
                if (transform.position == targetWayPoint)
                {
                    //Debug.Log(transform.position + "  " + targetWayPoint);
                    targetWayPointIndex = (targetWayPointIndex + 1) % wayPoints.Length;
                    targetWayPoint = wayPoints[targetWayPointIndex];
                    yield return new WaitForSeconds(waitTime);
                    yield return StartCoroutine(TurnFace(targetWayPoint));
                }
            }
            yield return null;
        }
    }
    IEnumerator TurnFace(Vector3 lockTarget)
    {
        dirToLookTarget = (lockTarget - transform.position).normalized;
        turnAngle = 90 - Mathf.Atan2(dirToLookTarget.y, dirToLookTarget.x) * Mathf.Rad2Deg;
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, turnAngle)) > .05f)
        {
            angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, turnAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.forward * angle;
            print(transform.eulerAngles);

            yield return null;
        }
        isPlayerDetected = 0;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerMovement.myPlayer != null && (PlayerMovement.myPlayer.transform.position - transform.position).magnitude < 18)
        {
            isPlayerDetected = 1;
            //transform.LookAt(PlayerMovement.myPlayer.transform.position);
            //if ((PlayerMovement.myPlayer.transform.position - transform.position).magnitude > 8)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerMovement.myPlayer.transform.position, speed * Time.deltaTime * 2);
            }
            //Vector3.MoveTowards(transform.position,)
            /*if (counter > delay && PlayerMovement.myPlayer != null)
            {
                print("ok");
                /////////Instantiate(bullet, transform.position, transform.rotation);
                counter = 0;
            }*/
        }
        else if (isPlayerDetected == 1)
        {
            isPlayerDetected = -1;
            //StartCoroutine(TurnFace(targetWayPoint));
        }
    }

    void OnDrawGizmos()
    {
        /*foreach(Transform wayPoint in PathHolder)
        {
            Gizmos.DrawSphere(wayPoint.position, .3f);
        }*/
        int temp;
        Vector3 previosPosition = PathHolder.GetChild(0).position;
        Transform t;
        //Color c = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        //c.a /= 2;
        Gizmos.color = Color.black / 2;
        temp = PathHolder.childCount;
        for (int i = 0; i < temp; i++)
        {
            t = PathHolder.GetChild(i);
            Gizmos.DrawSphere(t.position, .2f);
            Gizmos.DrawLine(previosPosition, t.position);
            Gizmos.DrawLine(transform.position, t.position);
            previosPosition = t.position;
        }
        Gizmos.DrawLine(previosPosition, PathHolder.GetChild(0).position);

    }
    
}
