using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerSystem : Singleton<TimerSystem>
{
    private HashSet<TimeAgent> timeAgents = new();
    private HashSet<TimeAgent> disableTimeAgents = new();

    private void Update()
    {
        foreach (var agent in timeAgents)
        {
            agent.OnUpdateAction?.Invoke(agent);
            agent.CurrentTime += Time.deltaTime;

            if (agent.CurrentTime >= agent.MaxTime)
            {
                disableTimeAgents.Add(agent);
            }
        }

        if (disableTimeAgents.Count <= 0)
        {
            return;
        }

        foreach (var agent in disableTimeAgents)
        {
            agent.OnDisableAction?.Invoke(agent);
            timeAgents.Remove(agent);
        }
    }
}

public class TimeAgent
{
    public Action<TimeAgent> OnUpdateAction { get; private set; }
    public Action<TimeAgent> OnDisableAction { get; private set; }

    public float MaxTime { get; private set; }
    public float CurrentTime;

    public TimeAgent(float maxTime, Action<TimeAgent> onUpdateAction = null, Action<TimeAgent> onDisableAction = null)
    {
        OnUpdateAction = onUpdateAction;
        OnDisableAction = onDisableAction;
        MaxTime = maxTime;
    }
}
