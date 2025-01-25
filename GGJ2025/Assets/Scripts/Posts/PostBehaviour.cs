using System;
using Posts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PostBehaviour : BasePost
{
    public GameObject[] comments;

    private void Start()
    {
        names.text = userNickname + " @" + userName;
        userIcon.sprite = icon;
        switch (type)
        {
            case Content.ContentType.TextPost:
                contentText.text = content.contentText;
                
                break;
            case Content.ContentType.ImagePost:
                contentText.text = content.contentText;
                contentImage.sprite = content.contentImage;

                break;
            default:
                break;
        }
    }
}
