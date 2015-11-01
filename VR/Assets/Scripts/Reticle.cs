using UnityEngine;

public class Reticle : MonoBehaviour {

    // Use this for initialization
    private void Start() {
    }

    // Update is called once per frame
    private void Update() {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 0.75f);
    }
}