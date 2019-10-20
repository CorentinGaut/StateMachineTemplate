using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryState : State
{
    private Vector3 nextDestination;
    public HungryState(Player player) : base(player) { }

    public override void Tick()
    {
        if (player.food != null)
        {
            player.MoveToward(player.food.transform.position);
        }
        else
        {
            if (ReachedDestination())
            {
                nextDestination = GetRandomDestination();
            }

            player.MoveToward(nextDestination);
        }
    }

    public override void OnStateEnter()
    {
        player.GetComponent<Renderer>().material.color = Color.red;
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
