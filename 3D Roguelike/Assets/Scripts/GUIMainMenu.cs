using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIMainMenu : MonoBehaviour {
	private bool music = true;
	private bool creds = false;

	public GameObject creditsPanel;
	public GameObject quitPanel;

	public void onPlay() {
		SceneManager.LoadScene("Level");
	}

	public void onCredits() {
		creds = !creds;
		creditsPanel.SetActive(creds);
	}

	public void onQuit() {
		quitPanel.SetActive(true);
	}

	public void onQuitYes() {
		Application.Quit();
	}

	public void onQuitNo() {
		quitPanel.SetActive(false);
	}

	public void toggleMusic() {
		music = !music;
		// Add music stuff
	}
}