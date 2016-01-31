using UnityEngine;
using System.Collections;

public class Butler : MonoBehaviour
{

    [SerializeField] private Transform[] waypoints;
    private NavMeshAgent navAgent;
    private Transform placeToGo;
	// Use this for initialization
	void Start ()
	{
	    navAgent = GetComponent<NavMeshAgent>();
	    placeToGo = waypoints[Random.Range(0, waypoints.Length - 1)];
        navAgent.SetDestination(placeToGo.position);
    }
	
	// Update is called once per frame
	void Update () {
	    if (Vector3.Distance(transform.position, placeToGo.position) < 1) 
        {
            placeToGo = waypoints[Random.Range(0, waypoints.Length - 1)];
            navAgent.SetDestination(placeToGo.position);
            
        }
	}
}
