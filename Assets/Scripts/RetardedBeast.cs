using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetardedBeast : MonoBehaviour
{

    public float zombieSightRadius = 10;
    private Transform player;

    Animator animator;
    Transform randomTransform;
    float secondsCounter;
    Random random;

    public float attackRate = 0.5f;
    public int zombieDmg = 10;
    public float zombieAttackRange = 1f;

    private float cooldown = 0;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.LookAt(new Vector3(Random.Range(-125, 125), 1, Random.Range(-125, 125)));

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("IsNear") && !animator.GetBool("IsSoClose"))
        {
            secondsCounter++;
        }

        if (secondsCounter > 15f / Time.fixedDeltaTime) //      how many seconds
        {
            transform.LookAt(new Vector3(Random.Range(-125, 125), 1, Random.Range(-125, 125)));
            secondsCounter = 0;
            Debug.Log("Rotateg");
        }

        if (Mathf.Abs(Vector3.Distance(transform.position, player.position)) < zombieSightRadius && Mathf.Abs(Vector3.Distance(transform.position, player.position)) > zombieAttackRange)
        {
            animator.SetBool("IsSoClose", false);
            animator.SetBool("IsNear", true);
            transform.LookAt(player.position);
            Debug.Log("See");
        }
        if(Mathf.Abs(Vector3.Distance(transform.position, player.position)) > zombieSightRadius)
        {
            animator.SetBool("IsSoClose", false);
            animator.SetBool("IsNear", false);
            Debug.Log("Alone");
        }

        cooldown -= Time.deltaTime;
        if (Mathf.Abs(Vector3.Distance(player.position, transform.position)) < zombieAttackRange && cooldown < 0)
        {
            cooldown = 1 / attackRate;
            player.GetComponent<PlayerStatisticsController>().getDamaged(zombieDmg);
        }

        if (Mathf.Abs(Vector3.Distance(player.position, transform.position)) < zombieAttackRange)
        {
            animator.SetBool("IsSoClose", true);
            animator.SetBool("IsNear", false);
            Debug.Log("Hit");
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        if (!animator.GetBool("IsKilled"))
    //            transform.LookAt(other.transform);

    //        secondsCounter = 0;

    //        if (other.GetType() == typeof(CapsuleCollider))
    //        {

    //        }
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        if (!animator.GetBool("IsKilled"))
    //        {
    //            transform.LookAt(other.transform);

    //            if (other.GetType() == typeof(CapsuleCollider))
    //            {
    //                animator.SetBool("IsSoClose", true);
    //                animator.SetBool("IsNear", false);
    //            }
    //            else if (other.GetType() == typeof(SphereCollider))
    //            {
    //                animator.SetBool("IsSoClose", false);
    //                animator.SetBool("IsNear", true);
    //            }
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //if (other.gameObject.CompareTag("Player"))
    //    //{
    //    //    if (!animator.GetBool("IsKilled"))
    //    //    {
    //    //        transform.LookAt(new Vector3(Random.Range(-125, 125), 1, Random.Range(-125, 125)));
    //    //        animator.SetBool("IsNear", false);
    //    //    }
    //    //}

    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        if (!animator.GetBool("IsKilled"))
    //            transform.LookAt(new Vector3(Random.Range(-125, 125), 1, Random.Range(-125, 125)));

    //        secondsCounter = 0;

    //        if (other.GetType() == typeof(CapsuleCollider))
    //        {
    //            animator.SetBool("IsSoClose", false);
    //            animator.SetBool("IsNear", true);
    //        }
    //        else if (other.GetType() == typeof(SphereCollider))
    //        {
    //            animator.SetBool("IsSoClose", true);
    //            animator.SetBool("IsNear", false);
    //        }
    //    }
    //}
}
