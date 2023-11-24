using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Gworld
{
    private static readonly Gworld instance = new Gworld();
    private static WorldStates world;
    private static Queue<GameObject> patients;
    private static Queue<GameObject> cubicles;

    static Gworld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();

        GameObject[] cubes = GAction.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject c in cubes)
            cubicles.Enqueue(c);

        if(cubes.Length < 0)
            world.ModifyState("FreeCCubicle", cubes.Length);
    }
    private Gworld()
    {
    }

    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
    }

    public GameObject RemovePatient()
    {
        if(patients.Count == 0) return null;
        return patients.Dequeue();
    }  

        public void AddCubicle(GameObject p)
    {
        cubicles.Enqueue(p);
    }

    public GameObject RemoveCubicle()
    {
        if(cubicles.Count == 0) return null;
        return cubicles.Dequeue();
    } 

    public static Gworld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
