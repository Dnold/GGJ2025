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
        if (levelManager.posts == null)
        {
            int rand = 0;
            List<int> possible = Enumerable.Range(0, 5).ToList();
            for (int i = 0; i < 3; i++)
            {
                rand = UnityEngine.Random.Range(0, 5);
                levelManager.posts[i] = SceneManager.GetSceneByName("Level " + levelManager.currentLevel + "/Tweet" + possible[rand]);
                possible.RemoveAt(i);
            } 
        }
        levelManager.postCompleted.AddListener(levelManager.nextPost);
    }
}
