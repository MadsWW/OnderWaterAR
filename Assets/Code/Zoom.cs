using System;
using UnityEngine;

public class Zoom : MonoBehaviour {

    private GameObject activeLevel;

    private float minFOV = 1f;
    private float maxFOV = 2f;
    private float zoomIntensity = 0.01f;
    private float clampedScale = 1;


    #region Private_Methods
    // Update is called once per frame
    private void Update ()
    {
        ZoomScene();
    }

    // Checks for touch input every frame, if two or more fingers slide accross the screen you scale the level accordingly.
    private void ZoomScene()
    {
        if (activeLevel != null)
        {
            if (Input.touchCount > 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                CalculateScale();
                SetTargetScale();
            }
        }
    }
    
    // Calculates scale with accordance of the min/max scale/
    private void CalculateScale()
    {
        float touchPosChange = Input.GetTouch(0).deltaPosition.x;
        float changeScale = activeLevel.transform.localScale.x - (touchPosChange * zoomIntensity);
        clampedScale = Mathf.Clamp(changeScale, minFOV, maxFOV);
    }

    // Sets the scale of the active level.
    private void SetTargetScale()
    {
        Vector3 newScale = new Vector3(clampedScale, clampedScale, clampedScale);
        activeLevel.transform.localScale = newScale;
    }
    #endregion

    public void SetActiveLevel(GameObject go)
    {
        activeLevel = go;
    }

    public void EmpyActiveLevel()
    {
        activeLevel = null;
    }
}
