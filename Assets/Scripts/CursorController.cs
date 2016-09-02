using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour
{
    public float floatDistance;
    private float trueFloat;

    public void Awake()
    {
        parentField();
    }

    public void OnEnable()
    {

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
            trueFloat = hit.transform.localScale.y / 2 + floatDistance;
            Vector3 start = new Vector3(hit.transform.position.x,hit.transform.position.y + trueFloat,hit.transform.position.z);
        }
    }
}
