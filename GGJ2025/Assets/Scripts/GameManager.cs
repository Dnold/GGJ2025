using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public static GameManager instance;
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

    public void Start()
    {
        List<int> possible = Enumerable.Range(0, 5).ToList();
        if (levelManager.posts == null)
        {
            for (int i = 0; i < 3; i++)
            {
                levelManager.posts[i] = SceneManager.GetSceneByName("Level " + levelManager.currentLevel + "/Tweet" + possible[i]);
                possible.RemoveAt(i);
            } 
        }
    }
}
