using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject CanvaMenu;
    public GameObject CanvaLevels;

    private void Awake()
    {
        CanvaMenu.SetActive(true);
        CanvaLevels.SetActive(false);
    }


    public void Back()
    {
        CanvaMenu.SetActive(true);
        CanvaLevels.SetActive(false);
    }

    public void Play()
    {
        CanvaMenu.SetActive(false);
        CanvaLevels.SetActive(true);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
