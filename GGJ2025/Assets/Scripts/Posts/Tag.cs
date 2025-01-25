using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class Tag : MonoBehaviour
{
    public string tagName;
    public GameObject tagParent;
    public flag flag;
    bool isDragging = false;
    public GameObject clone;
    public int index;
    private EventSystem eventSystem;
    private GraphicRaycaster graphicRaycaster;

    void Start()
    {
        eventSystem = FindObjectOfType<EventSystem>();
        graphicRaycaster = FindObjectOfType<GraphicRaycaster>();
    }

    public void StartDrag()
    {
        //Put the tag on the cursor
        transform.SetParent(transform.root);
        isDragging = true;
        clone = Instantiate(gameObject, transform.position, Quaternion.identity, tagParent.transform);
        clone.transform.SetSiblingIndex(index);
    }

    public void Update()
    {
        if (isDragging)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void EndDrag()
    {
        Destroy(clone);
        //Put the tag back to the original position
        transform.SetParent(tagParent.transform);
        transform.SetSiblingIndex(index);
        transform.position = Vector3.zero;
        isDragging = false;

        // Perform UI Raycast
        List<RaycastResult> results = new List<RaycastResult>();
        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };
        graphicRaycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("Tag"))
            {
                CommentBehaviour comment = result.gameObject.GetComponentInParent<CommentBehaviour>();
                if (comment.flag == flag)
                {
                    result.gameObject.GetComponentInParent<CommentBehaviour>().isFound = true;
                    FindAnyObjectByType<PostBehaviour>().commentFound.Invoke();
                    Destroy(result.gameObject);
                }
            }
        }
    }
}
