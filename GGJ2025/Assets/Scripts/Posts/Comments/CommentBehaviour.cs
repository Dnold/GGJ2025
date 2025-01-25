using Posts;
using UnityEngine;

public class CommentBehaviour : BasePost
{
    enum flag{FakeNews, SexBot, HateSpeech, Spam, Scam, Child}
    
    private void Start() {
        names.text = userNickname + " @" + userName;
        userIcon.image = icon;
        switch (type)
        {
            case Content.ContentType.TextPost:
                contentText.text = content.contentText;
                contentImage.SetEnabled(false);
                break;
            case Content.ContentType.ImagePost:
                contentImage.image = content.contentImage;
                contentText.enabled = false;
                break;
            default:
                break;
        }
    }
}
