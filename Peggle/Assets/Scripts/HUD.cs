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
            Instantiate(Ball, Spawner.position, Quaternion.identity, Spawner);
            yield return new WaitForSeconds(.2f);
        }
    }

    public void Spawn()
    {
        Instantiate(Ball, Spawner.position, Quaternion.identity, Spawner);
    }

    public void LooseALife()
    {
        Destroy(Spawner.GetChild(0).gameObject);
    }

    private void Update()
    {
        ScoreText.text = Mathf.Floor(_manager.Score).ToString();
        MultiText.text = _manager.multiplicateur.ToString("F2");
        PowerText.text = _manager.ReversePower.ToString();
    }

}
