using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent Robot2;

    public GameObject Player;

    public float RobotDistanceRun = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        Robot2 = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);


        if (distance < RobotDistanceRun)
        {

            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            Robot2.SetDestination(newPos);
        }
    }
}
