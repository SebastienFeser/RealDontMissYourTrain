using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Here to check if the enemy CanRespawn condition is true
*/
public class StreetDeleteTrigger : MonoBehaviour {
    [SerializeField]private OnStreetEnnemies onStreetEnnemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            onStreetEnnemies.CanRespawn = true;
        }
    }
}
