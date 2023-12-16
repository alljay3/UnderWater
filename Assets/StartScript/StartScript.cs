using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    [SerializeField] GameObject MyPlayer;
    [SerializeField] GameObject TopBlock;
    [SerializeField] Level1 LevelScript;
    [SerializeField] TMPro.TextMeshProUGUI TextAir;
    [SerializeField] public int Air;
    [SerializeField] Image Fon;
    [SerializeField] Sprite SpriteFon;


    private void Start()
    {
        MainScript.InputOn = false;
        MainScript.curAir = Air;
        MainScript.Air = Air;
        TextAir.text = MainScript.curAir.ToString();
        MyPlayer.GetComponent<Animator>().SetBool("Start", false);
        MyPlayer.GetComponent<Rigidbody2D>().gravityScale = 20f;
    }

    private void Update()
    {
        MyPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(3f,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MyPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            TopBlock.SetActive(true);
            MainScript.InputOn = true;
            gameObject.SetActive(false);
            LevelScript.enabled = true;
            MyPlayer.GetComponent<Animator>().SetBool("Start", true);
            Fon.sprite = SpriteFon;
            MyPlayer.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }    
    }
}
