using UnityEngine;
using System.Collections;

public class ViewFinder : MonoBehaviour {

    public string actionButton;
    private Vector3 gazeStart;
    private Vector3 gazeEnd;
    public Object cursor;
	
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
                placeCursor(gazeStart, 1);
            }
                
        }
        if (Input.GetButtonUp(actionButton))
        {
            if (Physics.Raycast(ray, out hit))
            {
                gazeEnd = hit.point;
            }
        }
    }

    void placeCursor (Vector3 location,int type)
    {
        Transform properties;
        properties.position = Vector3.one;
        Instantiate(cursor);
    }
    
    bool checkDistance (Vector3 start, Vector3 end, float minimum)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(end.x - start.x, 2) + Mathf.Pow(end.y - start.y, 2) + Mathf.Pow(end.z - start.z, 2));
        if (distance > minimum)
        {
            return true;
        }
         else
        {
            return false;
        }
    }
}
