using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
   public List<Button> Buttons = new List<Button>();

    public void Launch(Button clicked)
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (Buttons[i] == clicked)
            {
                SceneManager.LoadScene(GameManager.Instance.Levels[i].name);
            }
        }
    }


}
