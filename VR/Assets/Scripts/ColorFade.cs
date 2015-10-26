using UnityEngine;
using System.Collections;

public class ColorFade : MonoBehaviour {

    Color startColor;
    Color endColor;
    float t = 0;
    float duration = 3;

    // Use this for initialization
    void Awake()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
            }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, t);
        if (t < 1)
        { // while t below the end limit...
          // increment it at the desired rate every update:
            t += Time.deltaTime / duration;
        }
    }

    public void changeColor(Color start, Color end, float duration) {
        float t = 0;
        gameObject.GetComponent<Renderer>().material.color = Color.Lerp(start, end, t);
        if (t < 1)
            {
                t += Time.deltaTime / duration;
            }
        }

}
