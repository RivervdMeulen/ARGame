using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameHandler : MonoBehaviour, IEvents {
    
    public void loadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void quitGame()
	{
		Application.Quit ();
	}

	public void EndMatch () {
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}

	public void ValueChange (float amount) {

	}

	public void TakeAction (bool playerTurn, bool defend) {

	}
}
