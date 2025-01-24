using System;
using Posts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PostBehaviour : BasePost
{
    public GameObject[] comments;

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
