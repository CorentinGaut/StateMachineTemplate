using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private State currentState;
    public GameObject food;
    public float speed = 2.5f;
    public bool eat = false;
    private void Start()
    {
        SetState(new FoolState(this));
    }

    private void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;
        gameObject.name = "Cube - " + state.GetType().Name;

        if (currentState != null)
            currentState.OnStateEnter();
    }

    public void MoveToward(Vector3 destination)
    {
        var direction = GetDirection(destination);
        transform.Translate(direction * Time.deltaTime * speed);
    }
     private Vector3 GetDirection(Vector3 destination)
    {
        return (destination - transform.position).normalized;
    }

    public void OnTriggerEnter(Collider other)
    {
        food = other.gameObject;
    }

    public void OnCollisionEnter(Collision collision)
    {
        eat = true;
        food = collision.gameObject;
    }
}
