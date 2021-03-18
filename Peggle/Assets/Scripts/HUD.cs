using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text ScoreText;
    public Text MultiText;
    public Text PowerText;
    public Transform Spawner;
    public GameObject Ball;

    private LevelManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<LevelManager>();

        StartCoroutine(SpawnLife());
    }

    IEnumerator SpawnLife()
    {
        for (int i = 0; i < _manager.Life; i++)
        {
            var inst = Instantiate(Ball, Spawner.position, Quaternion.identity, Spawner);
            yield return new WaitForSeconds(.2f);
        }
    }

    private void Update()
    {
        ScoreText.text = Mathf.Floor(_manager.Score).ToString();
        MultiText.text = _manager.multiplicateur.ToString("F2");
        PowerText.text = _manager.ReversePower.ToString();

        /*while (Spawner.childCount > _manager.Life)
        {
            Destroy(Spawner.GetChild(0).gameObject);
        }

        while (Spawner.childCount < _manager.Life)
        {
            Instantiate(Ball, Spawner.position, Quaternion.identity, Spawner);
        }*/
    }

}
