﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Player player;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(Player player)
    {
        this.player = player;
    } 
}
