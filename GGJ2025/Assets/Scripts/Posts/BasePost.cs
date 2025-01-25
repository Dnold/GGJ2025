using Microsoft.Unity.VisualStudio.Editor;
using Posts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasePost : MonoBehaviour
{
    public bool verified;
    public Content.ContentType type;
    public string userName;
    public string userNickname;
    public Content content;
    public Sprite icon;
    public TMP_Text names;
    public TMP_Text contentText;
    public UnityEngine.UI.Image contentImage;
    public UnityEngine.UI.Image userIcon;
    public bool isFound = true;
}
