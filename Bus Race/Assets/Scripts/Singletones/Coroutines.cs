using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private static Coroutines _objectInstance;

    private static Coroutines _instance
    {
        get
        {
            if (_objectInstance == null)
            {
                var gameObject = new GameObject("[COROUTINE INVOKER]");
                _objectInstance = gameObject.AddComponent<Coroutines>();
                DontDestroyOnLoad(_objectInstance.gameObject);
            }

            return _objectInstance;
        }
    }

    public static Coroutine StartRoutine(IEnumerator routine)
    {
        return _instance.StartCoroutine(routine);
    }

    public static void StopRoutine(Coroutine routine)
    {
        _instance.StopCoroutine(routine);
    }
}
