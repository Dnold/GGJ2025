using System;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    RectTransform rectTransform;
    void Start()
    { 
        rectTransform = gameObject.GetComponent<RectTransform>(); 
        Destroy(gameObject, 3.0f);
    }

    private void Update()
    {
        rectTransform.transform.Translate(240f * Time.deltaTime * Vector3.left);
    }
}
