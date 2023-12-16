using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octupus : MonoBehaviour
{
    [SerializeField] int Dmg;
    [SerializeField] int SpeedBullet;
    [SerializeField] GameObject BulletPrefab;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<Player>().TakeDmg(Dmg, gameObject.transform.position);
        }
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x < transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        Camera MyCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        float width = MyCamera.pixelWidth;
        float height = MyCamera.pixelHeight;
        Vector2 topLeft = MyCamera.ScreenToWorldPoint(new Vector2(0, height));
        Vector2 topRight = MyCamera.ScreenToWorldPoint(new Vector2(width, height));
        Vector2 bottomRight = MyCamera.ScreenToWorldPoint(new Vector2(width, 0));
        Vector2 bottomLeft = MyCamera.ScreenToWorldPoint(new Vector2(0, 0));
        if (topLeft.x - 3 > gameObject.transform.position.x || topRight.x + 3 < gameObject.transform.position.x)
        {
            Destroy(gameObject);
        }
        if (bottomLeft.y - 3 > gameObject.transform.position.y || topLeft.y + 3 < gameObject.transform.position.y)
        {
            Destroy(gameObject);
        }


    }


    public void SpawnBullet()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject bullet = GameObject.Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<EnemyBullet>().Dmg = Dmg;
        bullet.GetComponent<EnemyBullet>().Target = player.transform.position;
        bullet.GetComponent<EnemyBullet>().Speed = SpeedBullet;
    }
}
