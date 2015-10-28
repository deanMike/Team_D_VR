using UnityEngine;
using System.Collections;
//Mike Dean - Script to change color of object when looked at.
public class Look : MonoBehaviour {

    Camera cam;
    float t = 0;
    float duration = 3;
    VariableController variables;
    public AudioClip[] sounds = new AudioClip[3];
    Color warning;

    // Use this for initialization
    void Start () {
        //warning = GameObject.Find("Warning").GetComponent<Renderer>().material.color;
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        DontDestroyOnLoad(gameObject);

    }
	
	// Update is called once per frame
	void Update () {
        MakeRed(new Ray(cam.transform.position, cam.transform.forward));
        //FlashWarning();
        DontDestroyOnLoad(gameObject);
        if (Application.loadedLevel == 2) {
            transform.position = new Vector3(0, 1.8f, 1.5f);
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
        }
    }

    public void MakeRed(Ray ray)
    {
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.tag.Equals("Projectile")) {
                objectHit.SendMessage("Petrify");
                gameObject.GetComponent<AudioSource>().clip = sounds[new System.Random().Next(0, 3)];
                if (!gameObject.GetComponent<AudioSource>().isPlaying) {
                    gameObject.GetComponent<AudioSource>().Play();
                }
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
    public void FlashWarning() {
        warning = new Color(warning.r, warning.g, warning.b, 127);

        GameObject.Find("Warning").GetComponent<Renderer>().material.color = Color.Lerp(GameObject.Find("Warning").GetComponent<Renderer>().material.color, warning, t);
        if (t <1) {
            t += Time.deltaTime / duration;
        }
    }



}
