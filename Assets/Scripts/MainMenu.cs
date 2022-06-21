using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame() {
       SceneManager.LoadScene("SC Pixel Art Top Down - Basic");
   }

   public void QuitGame() {
       Application.Quit();
   }
}
