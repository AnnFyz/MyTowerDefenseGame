using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float damage = 50;
    public float speed = 10f;
    public GameObject impactEffect;
    public void Seek(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effect= Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 0.5f);
        Damage();
        //Destroy(target.gameObject);
        Destroy(gameObject, 0.5f);
    }

    void Damage()
    {
        Enemy e = target.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }
}
