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
    /// ///////////////////////////////////////////////////////////////////////////
    [SerializeField] private Image CRAFTING_MENU, ITEAM1, ITEAM2, ITEAM3;
    private Vector3 FULL_SC = new Vector3(0, 0, 0);
    private Vector3 CRAFT_SC = new Vector3(-9f, 59, 0);
    private bool CRAFT_MODE = false;
    private string CRAFTSLOT1, CRAFTSLOT2, craft_FINAL;
    private bool enadio = true;
    /// ///////////////////////////////////////////////////////////////////////////
    /// 

   
	



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
        
        if ((CRAFTSLOT1 =="pani" && CRAFTSLOT2 == "ksilo")|| (CRAFTSLOT1 == "ksilo" && CRAFTSLOT2 == "pani" ))
        {
           
            craft_FINAL = "simea";
            ITEAM3.sprite = MAIN.consumables[craft_FINAL].img;
        }
        else
        {
            craft_FINAL = null;
            ITEAM3.sprite = default;
        }

        if (CRAFT_MODE)
		{
            THE_menu.transform.localScale=new Vector3(0.75f, 0.75f, 0.75f);
            THE_menu.transform.localPosition = CRAFT_SC;
            CRAFTING_MENU.gameObject.SetActive(true);

                    



        }
		 if (THE_menu.gameObject.activeSelf == false || CRAFT_MODE == false)
		{
            CRAFTING_MENU.gameObject.SetActive(false);
            
            THE_menu.transform.localScale = new Vector3(1,1, 1);
            THE_menu.transform.localPosition = FULL_SC;
            CLEAR_CRAFT_TABLE();
        }

    }





        private void THE_CRAFT(string to_PRAMA_POU_BAZO)
	{
       
        if (enadio)
		{
              ITEAM1.sprite = MAIN.consumables[to_PRAMA_POU_BAZO].img;
            CRAFTSLOT1= to_PRAMA_POU_BAZO;
            Quick_remove(CRAFTSLOT1);
            enadio = false;
        }
        else
		{
			if (to_PRAMA_POU_BAZO != CRAFTSLOT1)
			{
                ITEAM2.sprite = MAIN.consumables[to_PRAMA_POU_BAZO].img;
                CRAFTSLOT2 = to_PRAMA_POU_BAZO;
                Quick_remove(CRAFTSLOT2);
            }
		}
	}
    
    private void CLEAR_CRAFT_TABLE()
	{
        if(CRAFTSLOT1 != default) MAIN.Instance.troo_i_apo8ikevo(CRAFTSLOT1, false);

        if (CRAFTSLOT2 != default) MAIN.Instance.troo_i_apo8ikevo(CRAFTSLOT2, false);

        ITEAM1.sprite = null;
        ITEAM2.sprite = null;
        ITEAM3.sprite = null;
        CRAFTSLOT1 = default;
        CRAFTSLOT2 = default;
        enadio = true;
        CRAFT_MODE =false;
    }
    public void CHANGE_ITEAM_OR_TAKE(int i)
	{
		switch (i)
		{
            case 1:
                   if (CRAFTSLOT1 != default)
                {
                    MAIN.Instance.troo_i_apo8ikevo(CRAFTSLOT1, false);
                                 enadio = true;
                                ITEAM1.sprite = null;
                                CRAFTSLOT1 = default;

				}
                break;
            case 2:
                if (CRAFTSLOT2 != default)
                {
                    MAIN.Instance.troo_i_apo8ikevo(CRAFTSLOT2, false);
                    enadio = false;
                    ITEAM2.sprite = null;
                    CRAFTSLOT2 = default;
                }
                break;

                
            case 3:
                    print("AAAAAAAAAAAAAAAAAAAAAAAA");
				if (craft_FINAL != null)
				{

                  
                    MAIN.Instance.troo_i_apo8ikevo(craft_FINAL,false);
                    REFRESH_IN();
                    CRAFTSLOT1 = default;
                    CRAFTSLOT2 = default;
                    CLEAR_CRAFT_TABLE();
                }
               
                break;

        }
    }
    private void Quick_remove(string str)
	{
        if (MAIN.INVENTORY[str] > 1)
        {
            MAIN.INVENTORY[str]--;
        }
        else
        {
            MAIN.INVENTORY.Remove(str);
        }
        REFRESH_IN();
    }
    /// ///////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////
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
                CRAFT_MODE = true;
                THE_CRAFT(CURRENT_ITEAMS_ON_DISPLAY[i]);
                    break;
                case 3:
				if (CURRENT_ITEAMS_ON_DISPLAY[i] == "simea")
				{
                    MAIN.Instance.SIMOS();
                    
                    Quick_remove(CURRENT_ITEAMS_ON_DISPLAY[i]);
                   

                }


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
