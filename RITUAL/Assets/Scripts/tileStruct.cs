using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct tile
{
    public bool[] connectionStates;

    public tile(bool[] tileState)
    {
        connectionStates = tileState;
    }
}