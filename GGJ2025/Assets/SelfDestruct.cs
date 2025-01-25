using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Start()
    {
     Destroy(gameObject, 3f);   
    }
}
