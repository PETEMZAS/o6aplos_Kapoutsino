using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Protagonist_stats : MonoBehaviour
{
    public static Protagonist_stats Instance;
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
        textt.text = (fai.ToString() + "  /   " + poto.ToString() + "  /   " + igiaa.ToString()+" /// "+ MAIN.state.ToString());
    }
    public void TROO_ODOS(float f, float p, float i)
    {
        fai += f;
        poto += p;
        igiaa += i;
    }
}
