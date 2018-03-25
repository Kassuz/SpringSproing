using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public float p1Health;
    public float p2Health;

    private void Awake()
    {
        p1Health = 100f;
        p2Health = 100f;
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
