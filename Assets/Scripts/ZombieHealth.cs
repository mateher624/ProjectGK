using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieHealth : MonoBehaviour
{

    public static int Damage = 5;

    public int Health;

    public ZombieHealth()
    {
        Health = 50;
    }

    public void LowerHealth(int damage)
    {
        Health -= Damage;
        if (Health < 0 && !GetComponent<Animator>().GetBool("IsKilled"))
        {
            GetComponent<Animator>().SetBool("IsKilled", true);
            GameObject.Find("GameController").GetComponent<GameController>().deleteZombie();
            GetComponent<RetardedBeast>().enabled = false;
            this.enabled = false;
        }
            
    }
}
