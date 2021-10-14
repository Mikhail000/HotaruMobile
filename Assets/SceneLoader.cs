﻿ using UnityEngine;

public class SceneLoader <T> : MonoBehaviour where T: MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            else if (instance != FindObjectOfType<T>())
            {

            }

            DontDestroyOnLoad(FindObjectOfType<T>());

            return instance;
        }
    }
}
