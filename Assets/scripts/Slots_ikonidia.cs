using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slots_ikonidia : MonoBehaviour
{
    [SerializeField]private int mynum;
    [SerializeField] private TextMeshProUGUI textt;
    public void SET_Q(string to_PRAMA)
    {
        textt.text = to_PRAMA;
    }
    public void PATI8IKA()
    {
        maininventory.instance.GET_CHILD_NUM(mynum);
    }
}
