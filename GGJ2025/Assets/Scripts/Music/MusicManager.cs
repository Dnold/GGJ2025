using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
public class MusicManager : MonoBehaviour
{
    public Instrument[] instruments;
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
    
  
    
    public void SetInstrumentVolume(Instrument instrument, float volume)
    {
        instruments.FirstOrDefault(e => e.id == instrument.id).source.volume = volume;
    }

  

}
