using System;
using Posts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.Linq;
using System.Collections.Generic;
public class PostBehaviour : BasePost
{
    public GameObject[] comments;
    public UnityEvent commentFound = new UnityEvent();

    private void Start()
    {
        names.text = userNickname + " @" + userName;
        userIcon.sprite = icon;
        verificationBadge.enabled = verified;
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
        commentFound.AddListener(OnCommentFound);
        FillAttributes();
    }
    public void FillAttributes()
    {
        likeNumText.text = UnityEngine.Random.Range(0, 5000).ToString();
        commentNumText.text = comments.Length.ToString();
        bookmarkNumText.text = UnityEngine.Random.Range(0, 5000).ToString();
        shareNumText.text = UnityEngine.Random.Range(0, 5000).ToString();
    }

    public void OnCommentFound()
    {
        //for (int i = 0; i < comments.Length; i++)
        //{
        //    if (comments[i].GetComponent<CommentBehaviour>().isFound && i == comments.Length - 1)
        //    {
        //        GameManager.instance.levelManager.postCompleted.Invoke();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        int count = comments.Count(c => c.GetComponent<CommentBehaviour>().isFound && c.GetComponent<CommentBehaviour>().flag != flag.Nothing);
        int countValid = comments.Count(c => c.GetComponent<CommentBehaviour>().flag != flag.Nothing);
        if(count == countValid)
        {
            GameManager.instance.postCompleted.Invoke();
        }
    }
}

