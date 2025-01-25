using Posts;
using UnityEngine;

public class CommentBehaviour : BasePost
{
    enum flag{FakeNews, SexBot, HateSpeech, Spam, Scam, Child}
    
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
