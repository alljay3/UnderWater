using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    [SerializeField] GameObject AirPrefab;
    [SerializeField] Camera MyCamera;
    [SerializeField] GameObject player;
    [SerializeField] GameObject SharkPrefab;
    [SerializeField] GameObject OverSharkPrefab;
    [SerializeField] GameObject OctopusPrefab;



    private void Start()
    {
        player.GetComponent<Player>().SpeedMove = MainScript.Speed;
        player.GetComponent<Player>().DashCooldown = MainScript.DashCooldown;
        MainScript.curAir = MainScript.Air;
        StartCoroutine("AirMinus");
        StartCoroutine("SpawnShark");
        StartCoroutine("SuperShark");
        StartCoroutine("SpawnAir");
        StartCoroutine("SpawnOctopus");
    }



    IEnumerator SpawnOctopus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            float width = MyCamera.pixelWidth;
            float height = MyCamera.pixelHeight;
            Vector2 coord = MyCamera.ScreenToWorldPoint(new Vector2(0, 0));
            coord.y -= 2;
            coord.x = Random.Range(MyCamera.ScreenToWorldPoint(new Vector2(0, 0)).x, MyCamera.ScreenToWorldPoint(new Vector2(width, 0)).x);
            GameObject.Instantiate(OctopusPrefab, coord, Quaternion.identity);
        }
    }




    IEnumerator SpawnAir()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            float width = MyCamera.pixelWidth;
            float height = MyCamera.pixelHeight;
            Vector2 coord = MyCamera.ScreenToWorldPoint(new Vector2(0, 0));
            coord.y -= 2;
            coord.x = Random.Range(MyCamera.ScreenToWorldPoint(new Vector2(0, 0)).x, MyCamera.ScreenToWorldPoint(new Vector2(width, 0)).x);
            GameObject.Instantiate(AirPrefab, coord, Quaternion.identity);
        }
    }

    IEnumerator SpawnShark()
    {
        while (true)
        {
            SpawnSharkFunk();
            yield return new WaitForSeconds(0.5f);
            SpawnUltraShark();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnUltraShark()
    {
        int rightorleft = Random.Range(0, 2);
        Vector2 coord = new Vector2();
        float width = MyCamera.pixelWidth;
        float height = MyCamera.pixelHeight;
        if (rightorleft == 0)
        {
            Vector2 bottomLeft = MyCamera.ScreenToWorldPoint(new Vector2(0, 0));
            Vector2 topLeft = MyCamera.ScreenToWorldPoint(new Vector2(0, height));
            coord.x = topLeft.x - 2;
            coord.y = Random.Range(bottomLeft.y - 2, topLeft.y - (topLeft.y - bottomLeft.y) / 2);
            GameObject shark = GameObject.Instantiate(OverSharkPrefab, coord, Quaternion.identity) as GameObject;
            shark.GetComponent<LightShark>().RightOrLeft = 1;
        }
        else
        {
            Vector2 bottomRight = MyCamera.ScreenToWorldPoint(new Vector2(width, 0));
            Vector2 topRight = MyCamera.ScreenToWorldPoint(new Vector2(width, height));
            coord.x = topRight.x + 2;
            coord.y = Random.Range(bottomRight.y - 2, topRight.y - (topRight.y - bottomRight.y) / 3);
            GameObject shark = GameObject.Instantiate(OverSharkPrefab, coord, Quaternion.identity) as GameObject;
            shark.GetComponent<LightShark>().RightOrLeft = -1;
        }
    }

    void SpawnSharkFunk()
    {
        int rightorleft = Random.Range(0, 2);
        Vector2 coord = new Vector2();
        float width = MyCamera.pixelWidth;
        float height = MyCamera.pixelHeight;
        if (rightorleft == 0)
        {
            Vector2 bottomLeft = MyCamera.ScreenToWorldPoint(new Vector2(0, 0));
            Vector2 topLeft = MyCamera.ScreenToWorldPoint(new Vector2(0, height));
            coord.x = topLeft.x - 2;
            coord.y = Random.Range(bottomLeft.y - 2, topLeft.y - (topLeft.y - bottomLeft.y) / 2);
            GameObject shark = GameObject.Instantiate(SharkPrefab, coord, Quaternion.identity) as GameObject;
            shark.GetComponent<LightShark>().RightOrLeft = 1;
        }
        else
        {
            Vector2 bottomRight = MyCamera.ScreenToWorldPoint(new Vector2(width, 0));
            Vector2 topRight = MyCamera.ScreenToWorldPoint(new Vector2(width, height));
            coord.x = topRight.x + 2;
            coord.y = Random.Range(bottomRight.y - 2, topRight.y - (topRight.y - bottomRight.y) / 3);
            GameObject shark = GameObject.Instantiate(SharkPrefab, coord, Quaternion.identity) as GameObject;
            shark.GetComponent<LightShark>().RightOrLeft = -1;
        }
    }



    IEnumerator AirMinus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            MainScript.curAir -= 1;
        }
    }
}
