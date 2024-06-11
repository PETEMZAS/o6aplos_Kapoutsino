using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ODOS_EGO : MonoBehaviour
{
    public static ODOS_EGO Instance;
    [SerializeField] private TextMeshProUGUI textt;
    public static float fai = 0;
    public static float poto = 0;
    public static float igiaa = 0;
    public void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        textt.text = fai.ToString() + "  /   " + poto.ToString() + "  /   " + igiaa.ToString()+" /// "+MAIN.INVENTORY.Count;
    }
    public void TROO_ODOS(float f, float p, float i)
    {
        fai += f;
        poto += p;
        igiaa += i;
    }
}
