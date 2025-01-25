using Posts;
using UnityEngine;
public enum flag { FakeNews, SexBot, HateSpeech, Spam, Scam, Child }
public class CommentBehaviour : BasePost
{
    
    public flag flag;
    private void Start() {
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
    }
}
