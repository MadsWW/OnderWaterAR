using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private static LevelManager levelManager;

	
	private void Awake ()
    {
        CheckForLevelManager();
    }

    // Singleton for LevelManager
    private void CheckForLevelManager()
    {
        if (levelManager == null)
        {
            DontDestroyOnLoad(gameObject);
            levelManager = this;
        }
        else if (levelManager != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
