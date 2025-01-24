using UnityEngine;
using System.Linq;
public static class MusicUtils
{
    public static Instrument GetInstrumentByName(Instrument[] instruments,string name)
    {
        return instruments.FirstOrDefault(i => i.name == name);
    }
    public static Instrument GetInstrumentByID(Instrument[] instruments,int id)
    {
        return instruments.FirstOrDefault(i => i.id == id);
    }
}
