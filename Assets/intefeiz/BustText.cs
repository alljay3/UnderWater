using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustText : MonoBehaviour
{
    // Start is called before the first frame update
    public void Ubrat()
    {
        StartCoroutine("MyTimeText");
    }
    IEnumerator MyTimeText()
    {
        Debug.Log("loh");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("loh");
        GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
    }
}
