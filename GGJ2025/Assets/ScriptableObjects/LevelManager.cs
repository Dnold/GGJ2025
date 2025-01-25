using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SceneManager", menuName = "Scriptable Objects/SceneManager")]
    public class LevelManager : ScriptableObject
    {
        public int currentLevel;
        public int completedPosts;
        public Scene[] posts;

        public UnityEvent postCompleted;
        
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
