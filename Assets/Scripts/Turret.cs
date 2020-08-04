using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public List<GameObject> enemys = new List<GameObject>();
    public float attackRateTime = 1;
    public GameObject bulletPrefab;

    public Transform firePosition;

    private float timer = 0;

    void Start()
    {
        timer = attackRateTime;
    }

    void Update()
    {
        timer += Time.deltaTime;
        print("Update " + enemys.Count + " " + timer);
        if (enemys.Count > 0 && timer >= attackRateTime)
        {
            timer -= attackRateTime;
            Attack();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            enemys.Add(collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            enemys.Remove(collider.gameObject);
        }
    }

    void Attack()
    {
        print("attack");
        GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
    }
}
