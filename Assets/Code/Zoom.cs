using System;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {

    //public Text TargetScaleText;

    private GameObject activeLevel;

    private float minFOV = 1f;
    private float maxFOV = 2f;
    private float zoomIntensity = 0.01f;

    float clampedScale = 1;

    // Update is called once per frame
    void Update ()
    {
        ZoomScene();
    }

    private void ZoomScene()
    {
        if (activeLevel != null)
        {
            // Tells clampedScale and actual scale of Level object.
            //string scaleText = string.Format("Clampscale: {0}  TargetScale: {1}", clampedScale, go.transform.localScale);
            //TargetScaleText.text = scaleText;

            if (Input.touchCount > 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                float touchPosChange = Input.GetTouch(0).deltaPosition.x;
                float changeScale = activeLevel.transform.localScale.x - (touchPosChange * zoomIntensity);
                clampedScale = Mathf.Clamp(changeScale, minFOV, maxFOV);

                activeLevel.transform.localScale = new Vector3(clampedScale, clampedScale, clampedScale);
            }
        }
    }

    public void SetActiveLevel(GameObject go)
    {
        activeLevel = go;
    }

    public void EmpyActiveLevel()
    {
        activeLevel = null;
    }
}
