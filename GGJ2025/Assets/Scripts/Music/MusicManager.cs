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
    public int currentStageID;

    public void Start()
    {
        SetStage(currentStageID);
    }
    public void Update()
    {
        if (GameManager.instance.currentTime < 9999.0f)
        {
            SetStage(1);
        }
        if (GameManager.instance.currentTime < 15.0f)
        {
            SetStage(2);
        }
        if (GameManager.instance.currentTime < 5.0f)
        {
            SetStage(3);
        }
        if (GameManager.instance.currentTime < 3.0f)
        {
            SetStage(4);
        }
    }
    public Stage[] stages;
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
       MusicUtils.GetInstrumentByID(instruments,instrument.id).source.volume = volume;
    }
    public void SetStage(int id)
    {
        Stage currentStage = stages.FirstOrDefault(s => s.id == id);
        for(int i = 0; i < instruments.Length; i++)
        {
            if (currentStage.instruments.FirstOrDefault(e=> e.id == instruments[i].id))
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
