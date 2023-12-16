using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBol : MonoBehaviour
{
    [SerializeField] int DopAir; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (MainScript.curAir + DopAir > MainScript.Air)
                MainScript.curAir = MainScript.Air;
            else
                MainScript.curAir += DopAir;

            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
    }


    private void Update()
    {
        Camera MyCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        float width = MyCamera.pixelWidth;
        float height = MyCamera.pixelHeight;
        Vector2 topLeft = MyCamera.ScreenToWorldPoint(new Vector2(0, height));
        if (topLeft.y + 4 < gameObject.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

}
