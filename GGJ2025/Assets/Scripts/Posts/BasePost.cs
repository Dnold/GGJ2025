using Posts;
using TMPro;
using UnityEngine;

public class BasePost : MonoBehaviour
{
    public Content.ContentType type;
    public string userName;
    public string userNickname;
    public Content content;
    public Sprite icon;
    public TextMeshPro names;
    public TextMeshPro contentText;
    public SpriteRenderer contentImage;
    public SpriteRenderer userIcon;
}
