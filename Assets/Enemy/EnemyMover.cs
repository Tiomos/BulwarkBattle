using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;


    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(followPath());
    }

   void Start()
   {
        enemy = GetComponent<Enemy>();
   }
   
    void FindPath()
    {
        path.Clear();
        
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if(waypoint !=null)
            {
                path.Add(waypoint);
            }
            
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

   void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }   
    IEnumerator followPath()
    {
        foreach(Waypoint waypoint in path)
        {
            UnityEngine.Vector3 startPosition = transform.position;
            UnityEngine.Vector3 endPosition = waypoint.transform.position;
            float travelPrecent = 0f;
            
           transform.LookAt(endPosition);
           
            while(travelPrecent < 1f)
            {
                travelPrecent += Time.deltaTime * speed;
                transform.position = UnityEngine.Vector3.Lerp(startPosition, endPosition, travelPrecent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
