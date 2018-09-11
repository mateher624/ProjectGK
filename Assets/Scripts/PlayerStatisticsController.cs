using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatisticsController : MonoBehaviour {

    public int Ammo = 0;
    public float FireRate = 5;
    public int health = 100;
    
    public void AddAmmo(int amount)
    {
        Ammo += amount;
        GetComponent<GunInventory>().currentGun.GetComponent<GunScript>().bulletsIHave += amount;
    }

    public void IncreaseFireRate(float amount)
    {
        FireRate += amount;
        ZombieHealth.Damage += 5;
    }

    public void getDamaged(int dmg)
    {
        health -= dmg;
        Debug.Log("hit " + dmg);
        if (health <= 0)
        {
            Debug.Log("Dead");
            GameObject.Find("GameController").GetComponent<GameController>().playerDied();
        }
    }
}
