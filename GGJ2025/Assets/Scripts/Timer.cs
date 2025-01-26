using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMPro.TMP_Text timerText;

    private void Update()
    {
        if (GameManager.instance.currentTime > 0)
        {
            timerText.text = GameManager.instance.currentTime.ToString("F2");
        }
       
    }
}
