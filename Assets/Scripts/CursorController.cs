using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

    public float floatDistance;
    private float trueFloat;
    private GameObject gameField;
    private float startTime;
    public Material idle;
    public Material active;
    private Renderer rend;

    void Start () {
        parentField();
        floatParent();
        //gameObject.SetActive(false);
        rend = GetComponent<Renderer>();
        rend.material = idle;
        startTime = 0;
	}

    void Update ()
    {
        if (startTime != 0)
        {
            if (Time.realtimeSinceStartup - startTime == 0.25f)
            {
                rend.material = active;
                transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z * 1.5f);
            }
            if (Time.realtimeSinceStartup - startTime == 0.75f)
            {
                rend.material = idle;
                transform.localScale = new Vector3(transform.localScale.x * 0.66666f, transform.localScale.y * 0.66666f, transform.localScale.z * 0.66666f);
            }
            if (Time.realtimeSinceStartup - startTime == 1f)
            {
                startTime = 0;
            }
        }
    }
	
	void parentField () {
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

    void floatParent ()
    {
        Vector3 defaultFloat = new Vector3(gameField.transform.position.x, gameField.transform.position.y + (gameField.transform.localScale.y / 2) + floatDistance, gameField.transform.position.z);
        transform.position = defaultFloat;
    }

    Vector3 translateToLocal (Vector3 original)
    {
        Vector3 local = new Vector3(original.x, transform.position.y, original.z);
        return local;
    }

    public void pingPosition (Vector3 position)
    {
        Vector3 destination = translateToLocal(position);
        transform.position = destination;
        gameObject.SetActive(true);
        startTime = Time.realtimeSinceStartup;
    }
}
