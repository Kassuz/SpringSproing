using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    public float p1Health;
    public float p2Health;

    public Slider p1HealthSlider;
    public Slider p2HealthSlider;

    private void Awake()
    {
        p1Health = 100f;
        p2Health = 100f;

        p1HealthSlider.maxValue = p1Health;
        p2HealthSlider.maxValue = p2Health;
    }

    public void TakeDamage(int player, float dmg)
    {
        if (player == 1)
        {
            p1Health -= dmg;
            Debug.Log("Player1 health! " + p1Health);
        }
        else
        {
            p2Health -= dmg;
            Debug.Log("Player2 health! " + p2Health);
        }
    }

    private void Update()
    {
        p1HealthSlider.value = p1Health;
        p2HealthSlider.value = p2Health;

        if (p1Health <= 0f)
        {
            Debug.Log("PLAYER 2 WINS PERKELE!!!");
            Time.timeScale = 0f;
        }
        else if (p2Health <= 0f)
        {
            Debug.Log("PLAYER 1 WINS PERKELE!!!");
            Time.timeScale = 0f;
        }
    }
}
