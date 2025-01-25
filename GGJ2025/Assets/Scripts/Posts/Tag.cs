using UnityEngine;
using UnityEngine.EventSystems;

public class Tag : MonoBehaviour
{
    public string tagName;
    public GameObject tagParent;
    public flag flag;
    bool isDragging = false;
    public GameObject clone;
    public int index;
    public void StartDrag()
    {
        //Put the tag on the cursor
        transform.SetParent(transform.root);
        isDragging = true;
        clone = Instantiate(gameObject, transform.position, Quaternion.identity,tagParent.transform);
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
    }

}
