using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class Resource
{
    public static T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
    
    public static GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        
        GameObject go = Object.Instantiate(original, parent);

        go.name = original.name;
        
        return go;
    }
    
    public void Destroy(GameObject go)
    {
        if (go == null)
        {
            return;
        }
        else
        {
            Object.Destroy(go);
        }
    }
}