using System;
using UnityEngine;

public class Instrument
{
    public Instrument(int id, string name, AudioClip loop)
    {
        this.id = id;
        this.name = name;
        this.loop = loop;
    }

    public int id;
    public string name;
    public AudioClip loop;
}
