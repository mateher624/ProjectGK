using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class RifflePowerupController : MonoBehaviour {

    public float RiffleFireRate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PickUp(other);

    }

    private void PickUp(Collider other)
    {
        var statsController = other.GetComponent<PlayerStatisticsController>();
        statsController.IncreaseFireRate(RiffleFireRate);

        Destroy(gameObject);
    }
}
