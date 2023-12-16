using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [HideInInspector]public float Speed;
    [HideInInspector]public Vector2 Target;
    [HideInInspector]public int Dmg;
    private Vector2  _naprVector;

    private void Start()
    {
        _naprVector = (Target - (Vector2)transform.position).normalized;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = _naprVector * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player>().TakeDmg(Dmg, transform.position);
        }
        else if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
