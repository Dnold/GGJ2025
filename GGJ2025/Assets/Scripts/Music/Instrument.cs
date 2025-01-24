using System;
using UnityEngine;
[System.Serializable]
public class Instrument : MonoBehaviour
{
    public int id;
    public string instrumentName;
    public AudioSource source;
    public AudioClip loop;
}
