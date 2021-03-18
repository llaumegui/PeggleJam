using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public MenuManager PreviousMenu;


    public enum Item
	{
        Play,
        Quit,
        Other,
	}

    public List<KeyCode> ValidateKeys;
    public List<KeyCode> CancelKeys;

    MenuObj _objHover;
    int _selectId;

    bool _antispamInputs;
    public List<MenuObj> Menus;

	private void Start()
	{
        SetupMenu();
	}

	// Update is called once per frame
	void Update()
    {
        Inputs();
    }

    void Inputs()
	{
        if(Menus.Count>0)
		{
            if (Input.GetAxisRaw("Vertical") != 0 && !_antispamInputs)
            {
                _antispamInputs = true;
                float select = Input.GetAxisRaw("Vertical");

                if (select < 0)
                {
                    _selectId--;
                    if (_selectId < 0)
                        _selectId = Menus.Count - 1;
                }
                else
                {
                    _selectId++;
                    if (_selectId > Menus.Count - 1)
                        _selectId = 0;
                }

                Hover();

                //feedback move
            }

            if (Input.GetAxisRaw("Vertical") == 0)
                _antispamInputs = false;

            foreach (KeyCode key in ValidateKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    _objHover.Select();
                }
            }

        }

        if (PreviousMenu != null)
		{
            foreach(KeyCode key in CancelKeys)
			{
                if(Input.GetKeyDown(key))
				{
                    PreviousMenu.gameObject.SetActive(true);
                    gameObject.SetActive(false);
				}

			}
		}
	}

    public void Hover(MenuObj obj = null)
	{

        if(obj == _objHover || _objHover == Menus[_selectId])
		{
            if (obj == null)
                _objHover = Menus[_selectId];
            else
            {
                foreach (MenuObj menu in Menus)
                {
                    if (menu == obj)
                        _objHover = menu;
                }
            }


            _objHover.FeedBackHover();
        }
    }

    public void Select(Item type)
	{
        switch(type)
		{
            case Item.Play:
                //
                break;
            case Item.Quit:
                //
                break;
		}

        _objHover.Select();
        //Feedback Select

	}

    void SetupMenu()
	{
        foreach (MenuObj menu in Menus)
            menu.Root = this;

        Hover();
    }

}
