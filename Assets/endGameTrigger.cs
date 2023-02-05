using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameTrigger : MonoBehaviour
{ 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameLogic.LoadLevel("_GameEnding");
        }

    }
}
