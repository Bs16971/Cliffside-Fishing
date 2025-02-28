using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

   [SerializeField] private string _playGame = "Fishing";
   [SerializeField] private string _shop = "Shop";
   public void NewGameButton()
   {
      SceneManager.LoadScene(_playGame);
      SceneManager.LoadScene(_shop);
   }
   
}
