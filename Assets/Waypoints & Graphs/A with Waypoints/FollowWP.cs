using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    float accuracy = 5.0f;
    float rotSpeed = 2.0f;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    public GameObject wpManager;

    void Start() {
        Time.timeScale = 5.0f;
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];

        Invoke("GotoRuin", 2.0f);
    }

    public void GotoHeli() {

        g.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GotoRuin() {

        g.AStar(currentNode, wps[7]);
        currentWP = 0;
    }

    public void GotoRock() {

        g.AStar(currentNode, wps[1]);
        currentWP = 0;
    }

    public void GotoFactory() {

        g.AStar(currentNode, wps[4]);
        currentWP = 0;
    }

    void LateUpdate() 
    {
        if (g.pathList.Count == 0 || currentWP >= g.pathList.Count)
        return;

    if (Vector3.Distance(g.pathList[currentWP].getId().transform.position, this.transform.position) > accuracy)
    {
        currentNode = g.pathList[currentWP].getId();
        currentWP++;
    }

    if (currentWP < g.pathList.Count)
    {
        goal = g.pathList[currentWP].getId().transform;
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;
        
        // Update rotation
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        
        // Update translation
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

       
}
