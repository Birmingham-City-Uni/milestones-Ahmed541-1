using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : state
{
    agent owner;
    public FleeState(agent owner, stateManager sm) : base(owner, sm) { }
    public override void Enter()
    {
        Debug.Log("Entering flee");
    }
    public override void Execute()
    {
        Debug.Log("Entering flee");
    }
    public override void Exit()
    {
        Debug.Log("Exiting flee");
    }
}
