using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
 

    public PlantController _PlantConttroler;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _PlantConttroler.PowerUp();
            this.gameObject.SetActive(false);
        }

    }
 
}
