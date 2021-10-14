using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : state
{

    agent owner;
    public IdleState(agent owner, stateManager sm): base(owner, sm) { }
    public override void Enter()
    {
        Debug.Log("Entering idle");
    }
    public override void Execute()
    {
        Debug.Log("Entering Execute");
    }
    public override void Exit()
    {
        Debug.Log("Entering Exit");
    }
}
