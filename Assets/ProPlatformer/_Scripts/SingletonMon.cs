/*
 * FileName: SingletonMono.cs
 * Author: Xiao Wu
 * Created: 09/25/2023
 */

using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
                    if (_instance == null)
                    {
                        GameObject singletonObj = new GameObject();
                        _instance = singletonObj.AddComponent<T>();
                        singletonObj.name = typeof(T).ToString() + " (Singleton)";

                        DontDestroyOnLoad(singletonObj);
                    }
                }
            }

            return _instance;
        }
    }
    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this as T;
    }
}
