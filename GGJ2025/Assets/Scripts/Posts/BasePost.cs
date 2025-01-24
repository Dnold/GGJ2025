using Microsoft.Unity.VisualStudio.Editor;
using Posts;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UIElements.Image;

public class BasePost : MonoBehaviour
{
    public Content.ContentType type;
    public string userName;
    public string userNickname;
    public Content content;
    public Texture icon;
    public TextMeshPro names;
    public TextMeshPro contentText;
    public Image contentImage;
    public Image userIcon;
}
