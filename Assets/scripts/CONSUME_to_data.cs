using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CONSUME_to_data
{
    public string name;
    public float pinas, dipsa, igia;
    public int quantity = 1;
    public Sprite img;
   
    public CONSUME_to_data(float pinas, float dipsa, float igia, string name, Sprite img)
    {

        this.pinas = pinas;
        this.dipsa = dipsa;
       
        this.igia = igia;
        this.name = name;
        this.img = img;
    }
    


}

