using Unity.VisualScripting;
using UnityEngine;

public class JanitorSpawner : MonoBehaviour
{
    public static JanitorSpawner instance;
    [SerializeField]
    private GameObject janitor;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public static void spawnJanitor(float y)
    {
        Instantiate(instance.janitor, new Vector3(-8, y, 0), instance.janitor.transform.rotation);
    }
}
