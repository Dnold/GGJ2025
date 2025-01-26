using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = System.Random;
[Serializable]
public struct Level
{
    public int level;
    [SerializeField]
    public List<int> sceneList;

}
public class GameManager : MonoBehaviour
{
    public UnityEvent postCompleted = new UnityEvent();
    public static GameManager instance;
    public Level[] levels = new Level[3];
    public bool postComplete = false;
    public void StartGame()
    {
        StartCoroutine(GameLoop());
    }
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
        postCompleted.AddListener(OnPostFinished);
    }
    IEnumerator GameLoop()
    {
       
        int currentLevel = 0;
       

        while (currentLevel < levels.Length)
        {
            List<int> tempScenes = levels[currentLevel].sceneList;
            int initalCount = tempScenes.Count;
            while(tempScenes.Count >= initalCount - 3)
            {
               int rand =  UnityEngine.Random.Range(0, tempScenes.Count);
                SceneManager.LoadScene(tempScenes[rand]);
                tempScenes.Remove(tempScenes[rand]);
                yield return new WaitUntil(() => postComplete);
                postComplete = false;
                
            }
            currentLevel++;
        }
    }
    private void OnPostFinished()
    {
        postComplete = true;
    }
}
