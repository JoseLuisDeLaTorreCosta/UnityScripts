using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine_Controller : MonoBehaviour
{
    protected State actual_state;
    
    // Start is called before the first frame update
    void Start()
    {
        SetFirstState();
    }

    // Update is called once per frame
    void Update()
    {
        actual_state.Action();
        for (int i = 0; i < actual_state.transitions.Length; ++i)
        {
            if (actual_state.transitions[i].CheckCondition())
            {
                actual_state = actual_state.transitions[i].nextState;
            }
        }
    }

    public abstract void SetFirstState();
}
