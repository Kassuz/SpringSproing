using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   
        }
        else
        {
            Destroy(gameObject);
        }
    }
}