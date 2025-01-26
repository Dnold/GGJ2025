using System.Collections;
using UnityEngine;

public class JanitorMenuWalk : MonoBehaviour
{
    public float movementDistance = 0.3f;
    public float movementTime = 0.5f;
    bool isMirrored = false;
    public float walkingDistance = 5;
    void Start()
    {
        StartCoroutine(WalkCycle());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Check if the mouse is over the object
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if(hit.collider != null && hit.collider.tag == "Janitor")
            {
                GetComponent<AudioSource>().Play();
            }
            

            
        }
    }
    IEnumerator WalkCycle()
    {
        while(true)
        {
            if (ShouldTurn())
            {
                GetComponent<SpriteRenderer>().flipX = !isMirrored;
            }
            if(isMirrored)
            {
                transform.position += new Vector3(-movementDistance, 0, 0);
            }
            else
            {
                transform.position += new Vector3(movementDistance, 0, 0);
            }
            yield return new WaitForSeconds(movementTime);
            
           

            
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(walkingDistance, 0, 0), new Vector3(walkingDistance, 10, 0));
        Gizmos.DrawLine(new Vector3(-walkingDistance, 0, 0), new Vector3(-walkingDistance, 10, 0));
    }
    bool ShouldTurn()
    {
        if (transform.position.x >= walkingDistance && !isMirrored)
        {
            isMirrored = true;
            return true;
        }
        else if (transform.position.x <= -walkingDistance && isMirrored)
        {
            isMirrored = false;
            return true;
        }
        return false;
    }
}
