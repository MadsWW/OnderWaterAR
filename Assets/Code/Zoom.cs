using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

    public GameObject go;

    private float maxFOV = 0.9f;
    private float minFOV = 1.1f;

	// Use this for initialization
	void Start ()
    {
        //cam = FindObjectOfType<Camera>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            //float touchPosChange = Input.GetTouch(0).deltaPosition.x;
            float touchPosChange = Input.GetTouch(0).deltaPosition.x;

            //float changeFOV = cam.fieldOfView - touchPosChange;
            float changeScale = go.transform.localScale.x - touchPosChange;

            //cam.fieldOfView = Mathf.Clamp( changeFOV, minFOV, maxFOV);
            go.transform.localScale = new Vector3(Mathf.Clamp(changeScale, minFOV, maxFOV),0,0);

        }

        if (Input.GetMouseButton(1))
        {
            float clickChangePos = Input.mouse
        }
    }
}
