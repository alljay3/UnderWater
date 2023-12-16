using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShark : MonoBehaviour
{
    [SerializeField] int Dmg = 0;
    [SerializeField] float speed = 0;
    [HideInInspector] public int RightOrLeft = 1;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<Player>().TakeDmg(Dmg,gameObject.transform.position);
        }
    }

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * RightOrLeft, 0);
        if (RightOrLeft == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }


    private void Update()
    {
        Camera MyCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        float width = MyCamera.pixelWidth;
        float height = MyCamera.pixelHeight;
        Vector2 topLeft = MyCamera.ScreenToWorldPoint(new Vector2(0, height));
        Vector2 topRight = MyCamera.ScreenToWorldPoint(new Vector2(width, height));
        if (topLeft.x - 5 > gameObject.transform.position.x || topRight.x + 5 < gameObject.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
