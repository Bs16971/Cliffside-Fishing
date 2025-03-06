using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private string _playGame = "Fishing";
    [SerializeField] private string _shop = "Shop";
    [SerializeField] private string _hook = "ShopHook";

    public void NewGameButton()
    {
        SceneManager.LoadScene(_playGame);
    }

    public void ShopSystem()
    {
        SceneManager.LoadScene(_shop);
    }

    public void HookSystem()
    {
        SceneManager.LoadScene(_hook);
    }
}