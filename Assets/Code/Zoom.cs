using UnityEngine;

public class Zoom : MonoBehaviour {

    [Header ("Put in ImageTarget GameObject for each level")]
    public GameObject LevelOne;
    public GameObject LevelTwo;
    public GameObject LevelThree;

    private float maxFOV = 0.9f;
    private float minFOV = 1.1f;

	// Update is called once per frame
	void Update ()
    {
        ZoomScene(LevelOne);
    }

    private void ZoomScene(GameObject go)
    {
        if (Input.touchCount > 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float touchPosChange = Input.GetTouch(0).deltaPosition.x;
            float changeScale = go.transform.localScale.x - touchPosChange;
            float clampedScale = Mathf.Clamp(changeScale, minFOV, maxFOV);

            go.transform.localScale = new Vector3(clampedScale, clampedScale, clampedScale);
        }
    }
}
