using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CONSUME_to_data
{
   
    public float pinas, dipsa, igia;
    public Sprite img;
    public bool can_EAT;
    public bool can_craft;
    public bool can_deploy;
    public CONSUME_to_data(float pinas, float dipsa, float igia,bool can_EAT, bool can_craft, bool can_deploy, Sprite img)
    {

        this.pinas = pinas;
        this.dipsa = dipsa;
        this.igia = igia;
        this.can_EAT = can_EAT;
        this.can_craft = can_craft;
        this.can_deploy = can_deploy;
        this.img = img;
    }
    


}

