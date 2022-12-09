using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateChangable
{
    protected void ChangeState(string stateName)
    {

    }

    protected void ChangeStateToPrevious()
    {

    }
}
