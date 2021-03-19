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
    public int scoreToLifeUp;
    public float multiMax;
    public Transform JaugeGauche;
    public Transform JaugeDroite;

    public GameObject CanvasLost;

    [HideInInspector] public int newScore = 0;

    private LevelManager _manager;


    private void Awake()
    {
        _manager = FindObjectOfType<LevelManager>();
        CanvasLost.SetActive(false);
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


        int JaugeGPos = -530 + (460 * (newScore/scoreToLifeUp));
        JaugeGauche.position = new Vector3(JaugeGauche.position.x, JaugeGPos, JaugeGauche.position.z);

        float JaugeDPos = -700 + (640 * (_manager.multiplicateur/multiMax));
        JaugeDroite.position = new Vector3(JaugeDroite.position.x, JaugeDPos, JaugeDroite.position.z);

        if (newScore >= scoreToLifeUp)
        {
            newScore = 0;
            _manager.GainALIfe(1);
        }
    }

}
