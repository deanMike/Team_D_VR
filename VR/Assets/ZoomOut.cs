using UnityEngine;
using System.Collections;

public class ZoomOut : MonoBehaviour {

    public float TargetFOV = 150f;
    public float Speed = 1.0f; //Will reach target value in 1sec. 2f will make it achieve in half second (1f/2f)... and so on!


    void Update() {

        if (Application.loadedLevel.Equals(2)) {
            transform.Translate(Vector3.down * Time.deltaTime * 3);
            Debug.Log("Something");
        }
    }
}
