using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
[System.Serializable]
public struct Stage
{
    public int id;
    public string name;
    public Instrument[] instruments;
}
public class MusicManager : MonoBehaviour
{


    public static Stage[] stages;
    public static Instrument[] instruments;
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
    
    
    
    public static void SetInstrumentVolume(Instrument instrument, float volume)
    {
       MusicUtils.GetInstrumentByID(instruments,instrument.id).source.volume = volume;
    }
    public static void SetStage(int id)
    {
        Stage currentStage = stages.FirstOrDefault(s => s.id == id);
        for(int i = 0; i < instruments.Length; i++)
        {
            if (instruments.FirstOrDefault(e => e.id == currentStage.id))
            {
                SetInstrumentVolume(instruments[i], 1f);
            }
            else
            {
                SetInstrumentVolume(instruments[i], 0f);
            }
        }
    }

  

}
