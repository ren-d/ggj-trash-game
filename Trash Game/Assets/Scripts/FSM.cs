using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Finite-State machine 
 
 
    - Game States


    information:

 
 
  */


//  information about interface classes 
// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces
public interface IState
{
    public void Enter();
    public void Execute();
    public void Exit();

}

public class StateMachine
{
    IState currentState;

    public void ChangeState(IState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
            currentState.Execute();
    }
}


public class Unit : MonoBehaviour
{

    StateMachine stateMachine = new StateMachine();



}

public class _Menu : IState
{
    
}

public class _Pause : IState
{

}

public class _Playing : IState
{

}

public class _Dialogue : IState
{

}




