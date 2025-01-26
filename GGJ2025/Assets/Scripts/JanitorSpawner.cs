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

    public static void spawnJanitor(CommentBehaviour janitorSpawnPoint)
    {
        GameObject janitorRef = Instantiate(instance.janitor, janitorSpawnPoint.transform);
    }
}
