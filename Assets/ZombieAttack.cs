using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{

    private Transform target;

    public float attackRate = 0.5f;
    public int zombieDmg = 10;
    public float zombieAttackRange = 2f;

    private float cooldown = 0;

    Animator animator;

    // Use this for initialization
    void Start ()
	{
	    target = GameObject.FindGameObjectWithTag("Player").transform;
	    animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    cooldown -= Time.deltaTime;
	    if (Mathf.Abs(Vector3.Distance(target.position, transform.position)) < zombieAttackRange && cooldown < 0)
	    {
	        cooldown = 1 / attackRate;
            target.GetComponent<PlayerStatisticsController>().getDamaged(zombieDmg);

	        animator.SetBool("IsSoClose", true);
	        animator.SetBool("IsNear", false);
        }
	}
}
