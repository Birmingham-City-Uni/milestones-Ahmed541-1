using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Action : MonoBehaviour
{

    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target; //location where action will happen
    public string targetTag; //pickup gameobject using tag
    public float duration = 0; //how long will action take?
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public NavMeshAgent agent; //attached to agent for movement
    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;
    public WorldStates agentBeliefs;
    public bool running = false; 

    public Action()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    public void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        if(preconditions != null)
        {
            foreach(WorldState w in preConditions)
            {
                preconditions.Add(w.key, w.value);
            }
        }
        if(afterEffects != null)
        {
            foreach (WorldState w in afterEffects)
            {
                effects.Add(w.key, w.value);
            }
        }
    }

    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string,int> conditions)
    {
        foreach(KeyValuePair<string, int> p in preconditions)
        {
            if (!conditions.ContainsKey(p.Key)) return false;
        }

        return true;
    }

    public abstract bool PrePerform(); // allow custom code to ensure things can be done before

    public abstract bool PostPerform(); // and after the action

}
