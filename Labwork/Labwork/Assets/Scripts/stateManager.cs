using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateManager 
{

    

    private Stack stack;

    public void Init(state startState)
    {
        this.stack = new Stack();
        stack.Push(startState);
        startState.Enter();
    }
 
    public bool popState()
    {
        if( stack.Count > 0)
        {
            getCurrState().Exit();
            stack.Pop();
            return true;
        }
        else { return false;  }
    }

    public bool pushState(state _pushme)
    {
        if (stack.Peek() != _pushme)
        {
            stack.Push(_pushme);
            getCurrState().Enter();
            return true;
        }
        else { return false; }
    }

    public state getCurrState()
    {
        return stack.Count > 0 ? (state)stack.Peek() : null;
    }

    public void Update()
    {
        if (getCurrState() != null) getCurrState().Execute();
    }
}
