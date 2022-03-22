using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }

    public virtual void Start()
    {
        StateMachine = new StateMachine();
    }

    public virtual void Update()
    {
        StateMachine.Tick();
    }

    public virtual void FixedUpdate()
    {
        StateMachine.FixedTick();
    }
}
