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
    [SerializeField] private Sprite keno;
    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        int ii = 0;
        if (MAINprotagonist.THE_REAL_INVENTORY.Count != 0)
        {
            foreach (CONSUME_to_data i in MAINprotagonist.THE_REAL_INVENTORY)
            {
                inslots[ii].sprite = i.img;
                inslots[ii].gameObject.GetComponent<Slots_ikonidia>().SET_Q(i.quantity.ToString());
                ii++;
            }
        }
        for (int y = ii; y <= 8; y++)
        {
            if(inslots[y]!=null) inslots[y].sprite = keno;
        }
    }
  public void GET_CHILD_NUM(int i )
    {
        if (MAINprotagonist.THE_REAL_INVENTORY.Count - 1 >= i)
        {

        ODOS_EGO.Instance.TROO_ODOS(MAINprotagonist.THE_REAL_INVENTORY[i].pinas, MAINprotagonist.THE_REAL_INVENTORY[i].dipsa, MAINprotagonist.THE_REAL_INVENTORY[i].igia);
            CHECK_Q(i);
        }
        
    }
    protected void CHECK_Q(int i )
    {
        if (MAINprotagonist.THE_REAL_INVENTORY[i].quantity > 1)
        {
            MAINprotagonist.THE_REAL_INVENTORY[i].quantity--;
        }
        else
        {
            MAINprotagonist.THE_REAL_INVENTORY.RemoveAt(i);
        }
    }
}
