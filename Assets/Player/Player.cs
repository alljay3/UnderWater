using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public float SpeedMove;
    [SerializeField] GameObject Lose;
    [SerializeField] float Weight;
    [SerializeField] bool isTakeDmg = false;
    [SerializeField] bool IsDashSet = false;
    [SerializeField] bool isGunSet = true;
    [SerializeField] GameObject Bullet;
    [SerializeField] public float ShootCooldown;
    [SerializeField] public float DashCooldown;
    [SerializeField] float DashTimeCount;
    [SerializeField] bool NaprRight = true;
    [HideInInspector]public bool _shootIsReady = true;
    [HideInInspector]public bool _dashIsReady = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
            NaprRight = false;
        if (Input.GetAxisRaw("Horizontal") > 0)
            NaprRight = true;
        if (MainScript.InputOn && !isTakeDmg)
        {
            Vector2 _moveVector = new Vector2();
            _moveVector.x = Input.GetAxisRaw("Horizontal");
            _moveVector.y = Input.GetAxisRaw("Vertical");
            gameObject.GetComponent<Rigidbody2D>().velocity = _moveVector * SpeedMove;
        }

        if (_shootIsReady && isGunSet && Input.GetButtonDown("Fire1") && MainScript.InputOn)
        {
            Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ѕозици€ мыши переводитс€ в координаты игры.
            Vector2 _naprVector = _mousePos - (Vector2)transform.position;
            GameObject bullet = GameObject.Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Bullet>().naprVector = _naprVector.normalized;
            float angle = Vector2.Angle(_naprVector, new Vector2(0, 1));
            Debug.Log(angle);
            if (_naprVector.x < 0)
            {
                bullet.transform.Rotate(new Vector3(0, 0, 1 * angle));
            }
            else
            {
                bullet.transform.Rotate(new Vector3(0, 0, -1 * angle));
            }
            _shootIsReady = false;
            StartCoroutine("ShootCooldowning");
        }

        if (MainScript.InputOn && Input.GetButtonDown("Jump") && _dashIsReady && IsDashSet)
        {
            Dash();
        }





        if (MainScript.curAir < 0)
        {
            Lose.SetActive(true);
        }

        
    }

    IEnumerator ShootCooldowning()
    {
        yield return new WaitForSeconds(ShootCooldown);
        _shootIsReady = true;
    }


    public void Dash()
    {
        if (!isTakeDmg)
        {
            _dashIsReady = false;
            isTakeDmg = true;
            StartCoroutine("DashTime");
            StartCoroutine("SpriteFlicker");
            Vector2 coord;
            if (NaprRight)
            {
                coord = new Vector2(1,0);
            }
            else
            {
                coord = new Vector2(-1,0);
            }
            transform.GetComponent<Rigidbody2D>().velocity = coord.normalized * 10 * Weight;
        }
    }


    IEnumerator DashTime()
    {
        yield return new WaitForSeconds(DashTimeCount);
        isTakeDmg = false;
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        StartCoroutine("DashCooldowning");
        Debug.Log("DashTime");
    }

    IEnumerator DashCooldowning()
    {
        Debug.Log("DashCloodowning");
        yield return new WaitForSeconds(DashCooldown);
        _dashIsReady = true;
        Debug.Log("DashOnCold");
    }

    public void TakeDmg(int dmg,Vector2 posintionDamage)
    {
       if (!isTakeDmg)
       {
            isTakeDmg = true;
            MainScript.curAir -= dmg;
            StartCoroutine("DmgRecive");
            StartCoroutine("SpriteFlicker");
            Vector2 coord = (Vector2)transform.position - posintionDamage;
            transform.GetComponent<Rigidbody2D>().velocity = coord.normalized * 4 * Weight; 
       }
    }

    IEnumerator DmgRecive()
    {
        yield return new WaitForSeconds(0.2f);
        isTakeDmg = false;
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    IEnumerator SpriteFlicker()
    {
        while (isTakeDmg == true)
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);
            yield return new WaitForSeconds(0.01f);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.8f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
