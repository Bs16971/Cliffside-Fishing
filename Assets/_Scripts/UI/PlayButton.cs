using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

   [SerializeField] private string playGame = "Fishing";
   public void NewGameButton()
   {
      SceneManager.LoadScene(playGame);
   }
}
