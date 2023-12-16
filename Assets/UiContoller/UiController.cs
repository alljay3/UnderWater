using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI TextAir;
    [SerializeField] Player player;
    [SerializeField] Image DeshCheck;
    [SerializeField] Image GunCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TextAir.text = MainScript.curAir.ToString();
        if (player._dashIsReady)
        {
            DeshCheck.color = new Color32(0, 178, 46, 255);
        }
        else
        {
            DeshCheck.color = new Color32(255, 21, 0,255);
        }
        if (player._shootIsReady)
        {
            GunCheck.color = new Color32(0, 178, 46, 255);
        }
        else
        {
            GunCheck.color = new Color32(255, 21, 0, 255);
        }
    }
}
