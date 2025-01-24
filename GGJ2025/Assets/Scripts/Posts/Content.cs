using System;
using TMPro;
using UnityEngine;

namespace Posts
{
    [Serializable]
    public struct Content
    {
        public string contentText;
        public Texture contentImage;

        public enum ContentType
        {
            TextPost,
            ImagePost
        }
    }
}