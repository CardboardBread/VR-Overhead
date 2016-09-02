using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour
{
    private float floatDistance;
    private ViewFinder controller;
    private Transform gameField;
    private Vector3 spawnPosition;

    public void OnEnable ()
    {
        floatDistance = 0.1f;
        spawnPosition = transform.position;
        parentField();
        controller = GameObject.Find("Main Camera").GetComponent<ViewFinder>();
        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
    }

    void parentField ()
    {
        Ray ray;
        RaycastHit hit;
        Vector3 position = transform.position;
        Vector3 down = -transform.up;
        ray = new Ray(position, down);

        if (Physics.Raycast(ray, out hit))
        {
            gameField = hit.transform;
            transform.position = localTranslate(hit.point);
        }
    }

    public void ageCheck ()
    {
        if (controller.gazeEnd == spawnPosition)
        {
            Debug.Log("Cursor on frame " + Time.frameCount + " keeping alive.");
        }
        else if (controller.gazeStart == spawnPosition)
        {
            Debug.Log("Cursor on frame " + Time.frameCount + " keeping alive.");
        }
        else
        {
            Debug.Log("Cursor on frame " + Time.frameCount + " self-terminating...");
            Destroy(transform.gameObject);
        }
    }

    Vector3 localTranslate (Vector3 original)
    {
        float trueFloat = gameField.localScale.y / 2 + floatDistance;
        Vector3 translate = new Vector3(original.x, trueFloat, original.z);
        return translate;
    }
}
