using UnityEngine;
using System.Linq;
public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public void Awake()
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

    Instrument[] instruments;
    

  

}
