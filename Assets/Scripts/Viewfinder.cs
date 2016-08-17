using UnityEngine;
using System.Collections;

public class Viewfinder : MonoBehaviour {

    public GameObject playSubject;
    public int moveSpeed;
    private int layerMask = 1 << 8;
    private Vector3 lookPoint;

	// Use this for initialization
	void Start () {
	    if (moveSpeed == 0)
        {
            Debug.Log("User-defined speed was 0, defaulting to 100...");
            moveSpeed = 100;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray;
        RaycastHit hit;
        Vector3 cameraPosition = transform.position;
        Vector3 cameraForward = transform.forward;
        ray = new Ray(cameraPosition, cameraForward);

        if (Input.GetButtonUp("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, layerMask))
            {
                lookPoint = hit.point;
                movePlayerTo(lookPoint);
            }
        }
    }

    void movePlayerTo (Vector3 position)
    {
        Vector3 oldPosition = playSubject.transform.position;
        Vector3 moveDistance = new Vector3(lookPoint.x - playSubject.transform.position.x, lookPoint.y - playSubject.transform.position.y, lookPoint.z - playSubject.transform.position.z);

        for (int i = 0; i == 100; i++)
        {
            float mult = i / 100;
            playSubject.transform.position = oldPosition + new Vector3(moveDistance.x * mult,moveDistance.y * mult,moveDistance.z * mult);
        }
    }
}