using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    public float levelTime = 15f; // Zeit in Sekunden
    public float currentTime;
    private int currentLevelIndex;
    private List<int> currentScenes;
    private bool roundEndedTime = false;
    private Coroutine timerCoroutine;

    public void StartGame()
    {
        StartCoroutine(GameLoop());
    }
    public void EndGame()
    {
        Application.Quit();
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
        currentLevelIndex = 0;

        while (currentLevelIndex < levels.Length)
        {
            currentScenes = new List<int>(levels[currentLevelIndex].sceneList);
            int initialCount = currentScenes.Count;
            int countIndex = 0;
            roundEndedTime = false;
            while (currentScenes.Count > 0)
            {
                int rand = UnityEngine.Random.Range(0, currentScenes.Count);
                SceneManager.LoadScene(currentScenes[rand]);
                currentScenes.RemoveAt(rand);

                // Start the timer for the level
                if (timerCoroutine != null)
                {
                    StopCoroutine(timerCoroutine);
                }
                timerCoroutine = StartCoroutine(LevelTimer());
               
                yield return new WaitUntil(() => postComplete || roundEndedTime);
                if (roundEndedTime)
                {
                    StopCoroutine(timerCoroutine);
                    break;
                }
                postComplete = false;
                roundEndedTime = false;
            }
            if (!roundEndedTime)
            {
                countIndex++;
                currentLevelIndex++;
                roundEndedTime = true;
            }
        }
    }

    private void OnPostFinished()
    {
        postComplete = true;
    }

    private IEnumerator LevelTimer()
    {
        currentTime = levelTime;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("Scenes/Loser");
        // Reset the currentScenes list and reload the first scene of the current level
    }

    public void RestartLevel()
    {
        // Reset the currentScenes list and reload the first scene of the current level
        roundEndedTime = true;
        currentScenes = new List<int>(levels[currentLevelIndex].sceneList);
        
    }

    public void IncreaseTime(float amount)
    {
        currentTime += amount;
    }
}
