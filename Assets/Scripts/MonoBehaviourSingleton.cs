using UnityEngine;
using Object = UnityEngine.Object;

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

        OnAwake();
    }

    internal virtual void OnAwake()
    {
        
    }

    public void OnDestroy()
    {
        Debug.Log($"Manager {name}");
        Destroy(gameObject);
    }
}