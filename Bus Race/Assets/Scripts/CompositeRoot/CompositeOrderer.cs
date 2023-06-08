using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CompositeOrderer : MonoBehaviour 
{
    [SerializeField] private List<CompositeRoot> _roots;
    
    private void Awake()
    {
        foreach(var root in _roots)
        {
            root.Compose();
            root.enabled = true;
        }
    }
}
