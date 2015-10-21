using UnityEngine;
using System.Collections;
//Mike Dean - Script to change color of object when looked at.
public class Look : MonoBehaviour {

    Camera cam;
    float t = 0;
    float duration = 3;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            objectHit.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, t);
            if (t < 1)
            { // while t below the end limit...
              // increment it at the desired rate every update:
                t += Time.deltaTime / duration;
            }
            // Do something with the object that was hit by the raycast.
        }

    }
	
	// Update is called once per frame
	void Update () {
        cam = Camera.main;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Debug.Log(objectHit.name);
            objectHit.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, t);
            if (t < 1)
            { // while t below the end limit...
              // increment it at the desired rate every update:
                t += Time.deltaTime / duration;
            }
            // Do something with the object that was hit by the raycast.
        }

    }
}
