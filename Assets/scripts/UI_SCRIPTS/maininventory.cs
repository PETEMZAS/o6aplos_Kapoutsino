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
    [SerializeField] public static List<string> CURRENT_ITEAMS_ON_DISPLAY = new List<string>();
    [SerializeField] public Image THE_menu;
    [SerializeField] private Sprite keno;
  


    public void Awake()
    {
        instance = this;
    }
	private void Start()
	{
        for (int yy = 0; yy < 9; yy++)
        {
            inslots[yy].gameObject.GetComponent<Slots_ikonidia>().SET_Q(0);
            inslots[yy].sprite = keno;
        }

    }
	public void Update()
    {
        //int ii = 0;
        //if (MAINprotagonist.THE_REAL_INVENTORY.Count != 0)
        //{
        //    foreach (CONSUME_to_data i in MAINprotagonist.THE_REAL_INVENTORY)
        //    {
        //        inslots[ii].sprite = i.img;
        //        ii++;
        //    }
        //}
        //for (int y = ii; y <= 8; y++)
        //{
        //    if(inslots[y]!=null) inslots[y].sprite = keno;
        //}
    }
    public void GET_CHILD_NUM_AND_OP(int i, int operation)//exis patisi kati sto inventory
    {
        
            switch (operation)
            {
                case 1:
                print(i);
                var auto = CURRENT_ITEAMS_ON_DISPLAY[i];
                    if (MAIN.INVENTORY[auto] > 1)
                    {
                        MAIN.INVENTORY[auto]--;

                    }
                    else
                    {
                        MAIN.INVENTORY.Remove(auto);
                    }

                    ODOS_EGO.Instance.TROO_ODOS(MAIN.consumables[auto].pinas, MAIN.consumables[auto].dipsa, MAIN.consumables[auto].igia);
                    REFRESH_IN();
                   break;
                case 2:
                    break;
                case 3:
                    break;

            }
        

	}
        
    
  
   public void REFRESH_IN()
	{
        for (int yy = 0; yy < 9; yy++)
        {
            inslots[yy].gameObject.GetComponent<Slots_ikonidia>().SET_Q(0);
            inslots[yy].sprite = keno;
            CURRENT_ITEAMS_ON_DISPLAY.Clear();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        int zz = 0;
        List<string> templist = new List<string>(MAIN.INVENTORY.Keys);
        for(int sx = 0; sx < MAIN.INVENTORY.Count; sx++)
		{
            inslots[zz].sprite = MAIN.consumables[templist[sx]].img;
            inslots[zz].gameObject.GetComponent<Slots_ikonidia>().SET_Q(MAIN.INVENTORY[templist[sx]]);
            CURRENT_ITEAMS_ON_DISPLAY.Add(templist[sx]);
            zz++;
		}

		
	}
}
