using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] string NameLvl;
    [SerializeField] bool lastLevel = false;
    [SerializeField] GameObject WinPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !lastLevel)
        {
            MainScript.Speed = collision.gameObject.GetComponent<Player>().SpeedMove;
            MainScript.DashCooldown = collision.gameObject.GetComponent<Player>().DashCooldown;
            MainScript.GunCooldown = collision.gameObject.GetComponent<Player>().ShootCooldown;
            SceneManager.LoadScene(NameLvl);
        }
        else if(collision.tag == "Player" && lastLevel)
        {
            WinPanel.SetActive(true);
        }
    }
}
