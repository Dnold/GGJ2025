using Posts;
using System.Xml.Linq;
using UnityEngine;
public enum flag { FakeNews, SexBot, HateSpeech, Spam, Scam, Child, Nothing }
public class CommentBehaviour : BasePost
{

    public flag flag;
    private void Start()
    {
        verificationBadge.enabled = verified;
        names.text = userNickname + " @" + userName;
        userIcon.sprite = icon;
        switch (type)
        {
            case Content.ContentType.TextPost:
                contentText.text = content.contentText;
                contentImage.enabled = false;
                break;
            case Content.ContentType.ImagePost:
                contentImage.sprite = content.contentImage;
                break;
            default:
                break;
        }

        if (flag == flag.Nothing)
        {
            isFound = true;
        }
        else
        {
            isFound = false;
        }
        FillAttributes();
    }
  
        public void FillAttributes()
        {
            likeNumText.text = (GenerateGaussianRandom(50, 25)+25).ToString();
            commentNumText.text = (GenerateGaussianRandom(15, 10) + 10).ToString();
            bookmarkNumText.text = (GenerateGaussianRandom(100, 30) + 10).ToString();
            shareNumText.text = (GenerateGaussianRandom(5, 20) + 10).ToString();
        }

        private int GenerateGaussianRandom(float mean, float stdDev)
        {
            float u1 = UnityEngine.Random.value;
            float u2 = UnityEngine.Random.value;
            float z0 = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos(2.0f * Mathf.PI * u2);
            float z1 = z0 * stdDev + mean;
            return Mathf.Clamp(Mathf.RoundToInt(z1), 0, 1000);
        }
       
    
}
