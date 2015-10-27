using UnityEngine;
using System.Collections;
//Mike Dean - Script to change color of object when looked at.
public class Look : MonoBehaviour {

    Camera cam;
    float t = 0;
    float duration = 3;
    VariableController variables;

	// Use this for initialization
	void Start () {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
        MakeRed(new Ray(cam.transform.position, cam.transform.forward));

    }

    public void MakeRed(Ray ray)
    {
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.tag.Equals("Projectile")) {
                objectHit.SendMessage("Petrify");
            }

            Debug.Log(objectHit.name);
            if (objectHit.tag.Equals("Look") || objectHit.tag.Equals("Projectile")) {
                objectHit.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, t);
                if (t < 1)
                { // while t below the end limit...
                  // increment it at the desired rate every update:
                    t += Time.deltaTime / duration;
                }
            }
            // Do something with the object that was hit by the raycast.
        }
    }

}
