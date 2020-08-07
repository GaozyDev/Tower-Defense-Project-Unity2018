using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public float attackRateTime = 1;
    public GameObject bulletPrefab;
    public Transform firePosition;
    public Transform head;
    public bool useLaser = false;
    public float damageRate = 70;
    public LineRenderer laserRenderer;
    public GameObject laserEffect;

    private List<GameObject> enemys = new List<GameObject>();
    private float timer = 0;

    void Start()
    {
        timer = attackRateTime;
    }

    void Update()
    {
        if (enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }

        if (!useLaser)
        {
            timer += Time.deltaTime;
            if (enemys.Count > 0 && timer >= attackRateTime)
            {
                timer = 0;
                Attack();
            }
        }
        else if (enemys.Count > 0)
        {
            if (enemys[0] == null)
            {
                UpdateEnemys();
            }

            if (enemys.Count > 0)
            {
                laserRenderer.enabled = true;
                laserEffect.SetActive(true);

                laserRenderer.SetPositions(new Vector3[] { firePosition.position, enemys[0].transform.position });
                enemys[0].GetComponent<Enemy>().TakeDamage(damageRate * Time.deltaTime);
                laserEffect.transform.position = enemys[0].transform.position;
                Vector3 pos = transform.position;
                pos.y = enemys[0].transform.position.y;
                laserEffect.transform.LookAt(pos);
            }
        }
        else
        {
            laserEffect.SetActive(false);
            laserRenderer.enabled = false;
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
        if (enemys[0] == null)
        {
            UpdateEnemys();
        }

        if (enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
        else
        {
            timer = attackRateTime;
        }
    }

    void UpdateEnemys()
    {
        List<int> emptyIndex = new List<int>();
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == null)
            {
                emptyIndex.Add(i);
            }
        }

        for (int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i] - i);
        }
    }
}
