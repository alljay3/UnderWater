using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revard : MonoBehaviour
{
    [SerializeField] int Air;
    [SerializeField] float Speed;
    [SerializeField] float DashReduce = 0;
    [SerializeField] float ShootReduce = 0;
    GameObject _bustTextObg;
    TMPro.TextMeshProUGUI _bustText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _bustTextObg = GameObject.FindGameObjectWithTag("BustText");
            _bustText = _bustTextObg.GetComponent<TMPro.TextMeshProUGUI>();
            string myText = "";
            Destroy(gameObject);
            if (Air != 0)
            {
                myText += "Air+\n";
            }
            if (Speed != 0)
            {
                myText += "Move speed+\n";
            }
            MainScript.Air += Air;
            MainScript.curAir += Air;
            collision.gameObject.GetComponent<Player>().SpeedMove += Speed;
            if (DashReduce != 0)
            {
                collision.gameObject.GetComponent<Player>().DashCooldown -= DashReduce;
                myText += "Dash cooldown reduce+\n";
            }

            if (ShootReduce != 0)
            {
                collision.gameObject.GetComponent<Player>().ShootCooldown -= ShootReduce;
                myText += "Shoot cooldown reduce+\n";
            }
            _bustText.text = myText;
            _bustTextObg.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            _bustTextObg.GetComponent<BustText>().Ubrat();


        }
    }


}
