using UnityEngine;
using UnityEngine.AI;

public class WaypointSystem : MonoBehaviour
{
    public float moveSpeed = 5;
    public float turnSpeed = 5;
    private NavMeshAgent Robot2;
    private int destPoint = 0;
    public Transform[] points;

    public GameObject Player;

    public float RobotDistanceRun = 4.0f;

    void Start()
    {
        Robot2 = GetComponent<NavMeshAgent>();
        

        GotoNextPoint();
    }


    void Update()
    {

        float distance = Vector3.Distance(transform.position, Player.transform.position);


        if (distance < RobotDistanceRun)
        {

            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            Robot2.SetDestination(newPos);
        }
        else if (!Robot2.pathPending && Robot2.remainingDistance < 0.5f)
            GotoNextPoint();

    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        Robot2.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
}