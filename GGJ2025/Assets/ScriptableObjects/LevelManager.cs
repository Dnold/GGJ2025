using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelManager", menuName = "Scriptable Objects/LevelManager")]
    public class LevelManager : ScriptableObject
    {
        public int currentLevel;
        public int completedPosts;
        public Scene[] posts;

        public UnityEvent postCompleted = new UnityEvent();
        
        public void nextPost()
        {
            try
            {
                SceneManager.LoadScene(posts[completedPosts].name);
            }
            catch
            {
                SceneManager.LoadScene("Level" + (currentLevel + 1));
            }
        }
    }
}
