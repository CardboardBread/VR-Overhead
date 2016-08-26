using UnityEngine;
using System.Collections;

public class ViewFinder : MonoBehaviour {

    private Vector3 gazePoint;
    public CursorController cursor;
    public string actionButton;
    private bool buttonPressed;

	void Start () {
        cursor = GameObject.Find("Cursor").GetComponent<CursorController>();
	}
	
	void Update () {
        Ray ray;
        RaycastHit hit;
        Vector3 cameraPosition = transform.position;
        Vector3 cameraForward = transform.forward;
        ray = new Ray(cameraPosition, cameraForward);
        
        if (Input.GetButtonDown(actionButton))
        {
            buttonPressed = true;
        }
        if (Input.GetButtonUp(actionButton))
        {
            buttonPressed = false;
        }
        if (buttonPressed == true)
        {
            if (Physics.Raycast(ray, out hit))
            {
                gazePoint = hit.point;
                cursor.pingPosition(gazePoint);
            }
        }
    }
}
