using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trenningUi : MonoBehaviour
{

    public void Start()
    {
        StartCoroutine("TimeLife");
    }
    IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
