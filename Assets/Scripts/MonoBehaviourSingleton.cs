using UnityEngine;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
{
    public static T Instance 
    {
        get 
        {
            if (instance != null) return instance;
            
            instance = FindObjectOfType<T>();
            
            if (instance != null) return instance;
            
            var obj = new GameObject();
            obj.name = typeof(T).Name;
            instance = obj.AddComponent<T>();

            return instance;
        }
    }
    
    private static T instance;
    [SerializeField] internal bool dontDestroyOnLoad;

    public virtual void Awake()
    {
        if (instance == null) 
        {
            instance = this as T;
            
        }
        else 
        {
            Destroy(gameObject);
        }

        if (dontDestroyOnLoad) 
        {
            DontDestroyOnLoad(gameObject);
        }

        OnAwake();
    }

    internal virtual void OnAwake()
    {
        
    }

    public void OnDestroy()
    {
        Debug.Log($"Destroyed singleton {name}");
        Destroy(gameObject);
    }
}