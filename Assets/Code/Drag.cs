using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make Interface(IDraggable) or abstract method (DragObject) later on!! or enum!
public class Drag : MonoBehaviour {

    float speed = 0.01f;
    Vector3 initialPos;

	// Use this for initialization
	void Start ()
    {
        initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Debug.Log("TouchingDragItem");
            Vector2 deltaPos = Input.GetTouch(0).deltaPosition;

            float xpos = Mathf.Clamp(deltaPos.x, initialPos.x -1, initialPos.x + 1); 
            float zpos = Mathf.Clamp(deltaPos.y, initialPos.z -1, initialPos.z + 1);

            transform.Translate(xpos * speed, 0, zpos * speed);
        }
	}
}
