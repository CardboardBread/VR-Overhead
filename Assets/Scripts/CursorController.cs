using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour
{

    public float floatDistance;
    private float trueFloat;
    private GameObject gameField;
    private float startTime;
    public Material idle;
    public Material active;
    private Renderer rend;
    private MeshRenderer meshRend;
    private Vector3 originalScale;

    void Awake()
    {
        parentField();
        floatParent();
        meshRend = GetComponent<MeshRenderer>();
        meshRend.enabled = false;
        rend = GetComponent<Renderer>();
        rend.material = idle;
        startTime = 0f;
        originalScale = transform.localScale;
    }

    void parentField()
    {
        Ray ray;
        RaycastHit hit;
        Vector3 position = transform.position;
        Vector3 down = -transform.up;
        ray = new Ray(position, down);

        if (Physics.Raycast(ray, out hit))
        {
            gameField = hit.transform.gameObject;
        }
    }

    void floatParent()
    {
        Vector3 defaultFloat = new Vector3(gameField.transform.position.x, gameField.transform.position.y + (gameField.transform.localScale.y / 2) + floatDistance, gameField.transform.position.z);
        transform.position = defaultFloat;
    }

    Vector3 translateToLocal(Vector3 original)
    {
        Vector3 local = new Vector3(original.x, transform.position.y, original.z);
        return local;
    }

    public void pingPosition(Vector3 position)
    {
        Vector3 destination = translateToLocal(position);
        transform.position = destination;
        meshRend.enabled = true;
        startTime = Time.realtimeSinceStartup;
    }

    void scale(float size)
    {
        transform.localScale = originalScale * size;
    }

    void highlight(float start, float end, float high)
    {
        float increment = 0.25f;
        float decrement = 1f - increment;

        if (end - start < increment)
        {
            float quarterDistance = end - start;
            scale(high * (quarterDistance / 0.25f));
        }
    }
}
