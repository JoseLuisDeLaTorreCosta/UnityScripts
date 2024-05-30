using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public Transition[] transitions;

    public abstract void Action();
}
