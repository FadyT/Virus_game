using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform PathHolder;
    public float speed=5;
    public float waitTime = .3f;
    int x;
    int targetWayPointIndex;
    Vector3 targetWayPoint;
    Vector3[] wayPoints;

	void Start () {
         wayPoints= new Vector3[PathHolder.childCount];
        for (int i=0;i<wayPoints.Length;i++)
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
        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint, speed * Time.deltaTime);
            if(transform.position==targetWayPoint)
            {
                //Debug.Log(transform.position+"  "+ targetWayPoint);
                targetWayPointIndex = (targetWayPointIndex + 1) % wayPoints.Length;
                targetWayPoint = wayPoints[targetWayPointIndex];
                yield return new WaitForSeconds(waitTime);
            }
            yield return null;
        }
    }
	// Update is called once per frame
	void Update () {
		
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
        Gizmos.color = Color.blue;
        temp=PathHolder.childCount;
        for (int i = 0; i < temp;i++)
        {
            t=PathHolder.GetChild(i);
            Gizmos.DrawSphere(t.position, .2f);
            Gizmos.DrawLine(previosPosition, t.position);
            previosPosition = t.position;
        }
        Gizmos.DrawLine(previosPosition, PathHolder.GetChild(0).position);
    }
    
}
