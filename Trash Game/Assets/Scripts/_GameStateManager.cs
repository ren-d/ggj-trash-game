using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameStateManager : MonoBehaviour
{
    private static _GameStateManager _instance;
    public static _GameStateManager Instance
    {
        // Makes sure that no class outside of _GameStateManager can change what _instance is set to
        get
        {
            if (_instance == null)
                Debug.LogError("_GameStateManager is _NULL_"); //checks if _instance is still valid

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}





