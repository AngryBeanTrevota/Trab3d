using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{

    public Animator enemyAnimator;
    public NavMeshAgent agent;

    private Transform player;
    public Collider fieldOfView;
    public float speed = 1.0f;

    //No time for proper state machine, we'll work with 2 variables then
    //Chasing, Patroling


    bool isChasingPlayer = false;
    bool isPatroling = false;





    List<Vector3> waypoints = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        agent.speed = speed;

        player =  FindObjectOfType<ThirdPersonController>().gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = speed;

        if (isChasingPlayer)
        {



            return;
        }






        

        //Handling the patrol state
        //Will folow a pattern

        
        //Do we need to put new waypoints?
        if (waypoints.Count == 0)
        {
            for(int i = 0;i < 5; i++)
            {
                waypoints.Add(new Vector3());


            }
            //Box of waypoints

            waypoints[0] = new Vector3(this.transform.position.x-50, this.transform.position.y,this.transform.position.z);
            waypoints[1] = new Vector3(this.transform.position.x-50, this.transform.position.y, this.transform.position.z+50);
            waypoints[2] = new Vector3(this.transform.position.x+50, this.transform.position.y, this.transform.position.z+50);
            waypoints[3] = new Vector3(this.transform.position.x+50, this.transform.position.y, this.transform.position.z);
            waypoints[4] = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

            Debug.Log("New waypoints calculated");


        }

        //Are we on a waypoint?
        if (Vector3.Distance(waypoints[0],this.transform.position) < 1.0f)
        {
            waypoints.Remove(waypoints[0]);
        }


        //If not, just keep the patrol
        if(waypoints.Count < 1)
        {
            return;
        }
        agent.destination = waypoints[0];
        enemyAnimator.SetBool("Moving", true);












    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {

            agent.SetDestination(player.position);
            enemyAnimator.SetBool("Moving", true);
            isChasingPlayer = true;
            isPatroling = false;


        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            enemyAnimator.SetBool("Moving", false);
            isChasingPlayer = false;

            isPatroling = false;


        }
    }

    public void increaseSpeed(float inc)
    {
        this.speed += inc;
    }
}

