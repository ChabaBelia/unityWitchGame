using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
	#region Singleton

	public static GameManager instance;

    public List<string> scenes;

    public GameObject playerPrefab;
    GameObject m_player;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}

		instance = this;

        m_player = Instantiate(playerPrefab);

        DontDestroyOnLoad(m_player);
        DontDestroyOnLoad(this.gameObject);
	}

	#endregion

    public void GoToScene(int idScene) {
        SceneManager.LoadScene(idScene);
    }

    public void GoToScene(string nameScene) {
        SceneManager.LoadScene(nameScene);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void GoToExitLevelMenu() {
        //SceneManager.LoadScene("ExitLevelMenuScene");
        SceneManager.LoadScene("SC Pixel Art Top Down - Basic");
    }

    public void ExitGame() {
        Application.Quit();
    }

    public GameObject getPlayer()
    {
        return m_player;
    }
}