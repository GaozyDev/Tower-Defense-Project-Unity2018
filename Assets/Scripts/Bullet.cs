using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 50;
    public float speed = 40;
    public GameObject explosionEffectPrefab;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<Enemy>().TakeDamage(damage);
            GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(effect, 1);
        }
    }
}
