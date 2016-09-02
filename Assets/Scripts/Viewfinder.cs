using UnityEngine;
using System.Collections;

public class ViewFinder : MonoBehaviour {

    public string actionButton;
    public Vector3 gazeStart;
    public Vector3 gazeEnd;
    public GameObject pointCursor;
    public GameObject directionCursor;
    private CursorController oldCursor;
	
	void Update () {
        Ray ray;
        RaycastHit hit;
        Vector3 cameraPosition = transform.position;
        Vector3 cameraForward = transform.forward;
        ray = new Ray(cameraPosition, cameraForward);
        
        if (Input.GetButtonDown(actionButton))
        {
            if (Physics.Raycast(ray, out hit))
            {
                gazeStart = hit.point;
            }
                
        }
        if (Input.GetButtonUp(actionButton))
        {
            if (Physics.Raycast(ray, out hit))
            {
                gazeEnd = hit.point;
                placeCursor();
            }
        }

        if (Input.GetButton(actionButton))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(gazeStart, hit.point);
            }
        }
    }

    void placeCursor ()
    { 
        if (checkDistance(gazeStart, gazeEnd, 1))
        {
            Vector3 heading = gazeEnd - gazeStart;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Instantiate(directionCursor, gazeStart, rotation);
        }
        else
        {
            Instantiate(pointCursor, gazeEnd, Quaternion.identity);
        }

        oldCursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorController>();
        oldCursor.ageCheck();
    }
    
    bool checkDistance (Vector3 start, Vector3 end, float minimum)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(end.x - start.x, 2) + Mathf.Pow(end.y - start.y, 2) + Mathf.Pow(end.z - start.z, 2));
        if (distance > minimum) { return true; } else { return false; }
    }
}
