using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slots_ikonidia : MonoBehaviour
{
    [SerializeField]private int mynum;
    [SerializeField] private TextMeshProUGUI textt;
    private int mycount =0;
    public void SET_Q(int poso)
    {
        
        textt.text = poso.ToString();
    }
    public void PATI8IKA()
    {
       // maininventory.instance.GET_CHILD_NUM(mynum);
        MINI_MENU.Instance.call_on_slot(mynum,this.transform);
        
    }
    
    
}
