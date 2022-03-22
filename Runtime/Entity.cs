using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }

    private void Start()
    {
        StateMachine = new StateMachine();
    }

    private void Update()
    {
        StateMachine.Tick();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedTick();
    }
}
