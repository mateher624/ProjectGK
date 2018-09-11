using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AmmoPowerupController : MonoBehaviour {

    public int AmmoAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PickUp(other);

    }

    private void PickUp(Collider other)
    {
        var statsController = other.GetComponent<PlayerStatisticsController>();
        statsController.AddAmmo(AmmoAmount);

        Destroy(gameObject);
    }
}
