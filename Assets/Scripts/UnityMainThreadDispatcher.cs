using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMainThreadDispatcher : MonoBehaviour
{
    private static UnityMainThreadDispatcher _instance;
    private readonly Queue<System.Action> _executionQueue = new Queue<System.Action>();

    public static UnityMainThreadDispatcher Instance()
    {
        if (!_instance)
        {
            _instance = FindObjectOfType<UnityMainThreadDispatcher>();

            if (!_instance)
            {
                var gameObject = new GameObject("UnityMainThreadDispatcher");
                _instance = gameObject.AddComponent<UnityMainThreadDispatcher>();
                DontDestroyOnLoad(gameObject);
            }
        }

        return _instance;
    }

    public void Enqueue(System.Action action)
    {
        lock (_executionQueue)
        {
            _executionQueue.Enqueue(action);
        }
    }

    private void Update()
    {
        while (_executionQueue.Count > 0)
        {
            _executionQueue.Dequeue().Invoke();
        }
    }
}