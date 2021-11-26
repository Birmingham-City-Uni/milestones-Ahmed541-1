using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public sealed class World //used for queues in resolving conflics later
{
    private static readonly World instance = new World();
    private static WorldStates world;


    static World()
    {
        world = new WorldStates();
    }

    private World()
    {

    }

    public static World Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }

}
