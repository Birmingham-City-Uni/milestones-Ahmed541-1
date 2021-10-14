using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : state
{

    float speed = 10.0f;

    Vector3 wp;

    float range = 20.0f;

    GameObject waypoint;

    agent owner;

    public WanderState(agent owner, stateManager sm) : base(owner, sm)
    {

    }

    public override void Enter()
    {
        Debug.Log("entering wander state");
        waypoint = GameObject.Find("waypoint");
    }
    public override void Execute()
    {
        Debug.Log("Executing wander state");

        agent.Move(speed, wp);

        if((agent.transform.position - wp).magnitude < 0.1f){
            Wander();
        }


    }

    public override void Exit()
    {
        Debug.Log("Exiting Wander state");
    }
    void Wander()
    {
        //picks a new waypoint
        wp = new Vector3(Random.Range(-range, range), agent.transform.position.y, Random.Range(-range, range));

        waypoint.transform.position = wp;
    }
}
