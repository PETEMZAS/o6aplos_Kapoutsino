using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class maininventory : MonoBehaviour
{
    
    public static maininventory instance;
    [SerializeField] public List<Image> inslots = new List<Image>();
    
    [SerializeField] public Image THE_menu;
    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        int ii = 0;
        if (MAINprotagonist.THE_REAL_INVENTORY_4_real.Count != 0)
        {
            foreach (CONSUME_to_data i in MAINprotagonist.THE_REAL_INVENTORY_4_real)
            {
                inslots[ii].sprite = i.img;
                ii++;
            }
        }

        

    }
  public void GET_CHILD_NUM(int i )
    {
        ODOS_EGO.Instance.TROO_ODOS(MAINprotagonist.THE_REAL_INVENTORY_4_real[i-1].pinas, MAINprotagonist.THE_REAL_INVENTORY_4_real[i-1].dipsa, MAINprotagonist.THE_REAL_INVENTORY_4_real[i-1].igia);
        MAINprotagonist.THE_REAL_INVENTORY_4_real.RemoveAt(i);
    }
}
