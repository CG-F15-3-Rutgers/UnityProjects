using UnityEngine;
using System.Collections;

public class BasicAgentScript : MonoBehaviour
{
    public Transform target1;
    NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target1.transform.position);
    }

}
