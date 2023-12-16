using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{

    [SerializeField] GameObject AirPrefab;
    [SerializeField] Camera MyCamera;
    [SerializeField] GameObject player;
    [SerializeField] GameObject SharkPrefab;



    private void Start()
    {
        StartCoroutine("AirMinus");
        StartCoroutine("SpawnShark");
        StartCoroutine("SpawnAir");
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
            yield return new WaitForSeconds(1.5f);
            SpawnSharkFunk();
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
