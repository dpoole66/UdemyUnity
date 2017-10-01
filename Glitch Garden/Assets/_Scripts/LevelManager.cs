using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    private int _activeSceneBuildIndex = 0;

    private void Start() {
        Invoke("LoadNextLevel", autoLoadNextLevelAfter);
    }

    private void Initialise() {
        Scene activeScene = SceneManager.GetActiveScene();
        _activeSceneBuildIndex = activeScene.buildIndex;
    }

    public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLevel() {
        SceneManager.LoadSceneAsync (++_activeSceneBuildIndex);
    }

}
