using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolState : State
{
    private Vector3 nextDestination;

    private float timer;
    private float fool = 10f;
    private float wanderTime = 5f;

    public FoolState(Player player): base(player) { }

    public override void Tick()
    {
        fool -= Time.deltaTime;
        if (ReachedDestination())
        {
            nextDestination = GetRandomDestination();
        }

        player.MoveToward(nextDestination);
        if (fool < 5f)
        {
            player.SetState(new HungryState(player));
        }
    }


    public override void OnStateEnter()
    {
        nextDestination = GetRandomDestination();
        timer = 0f;
        player.GetComponent<Renderer>().material.color = Color.blue;
    }


    private Vector3 GetRandomDestination()
    {
        return new Vector3(UnityEngine.Random.Range(-40, 40), 0f, UnityEngine.Random.Range(-40, 40));
    }

    private bool ReachedDestination()
    {
        return Vector3.Distance(player.transform.position, nextDestination) < 0.5f;
    }
}
