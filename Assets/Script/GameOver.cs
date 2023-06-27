using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    private void OnCollisionEnter2D(Collision2D other)
    {
        gameOver.gameObject.SetActive(true);
    }

}
