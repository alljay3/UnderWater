using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corall : MonoBehaviour
{
    [SerializeField] int Dmg = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDmg(Dmg,gameObject.transform.position);
        }
    }
}
