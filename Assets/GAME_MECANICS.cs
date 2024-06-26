using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using TMPro;

public class GAME_MECANICS : MonoBehaviour
{
    public static GAME_MECANICS Instance;
    private float CLOCK10 = 0;
    private float CLOCK15 = 0;
    private float CLOCK1 = 0;
    public static float STAMINA = 0;
    public static int GAMEPOINTS=0;
    private Transform tempfix;
    [SerializeField] private TextMeshProUGUI textt;
	private void Awake()
	{
        Instance = this;
	}
    
    public void PLUS_GP(int num)
	{
        GAMEPOINTS += num;

    }
	
	void Update()
    {
        textt.text = GAMEPOINTS.ToString();
		if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) )
		{
          
            STAMINA += Time.deltaTime;
        }
        CLOCK10 += Time.deltaTime;
        CLOCK1 += Time.deltaTime;
        CLOCK15 += Time.deltaTime;
        if (CLOCK10>10)//ana 10 sec
		{
            CLOCK10 = 0;
            //fai
            if (maininventory.fai < 0.5f ) GAMEPOINTS--;
            //nero
            if (maininventory.poto < 0.5f) GAMEPOINTS--;
            //igia
            if (maininventory.igiaa < 0.5f) GAMEPOINTS--; //DEN TO EXIS ORISI
														  //
			
        }

        if (CLOCK15> 15)//ana 15 sec
        {
            CLOCK15 = 0;
            //fai
            if (maininventory.fai > 0.5f && maininventory.fai < 0.7f) GAMEPOINTS++;
            //nero
            if (maininventory.poto > 0.45f && maininventory.poto < 0.75f) GAMEPOINTS++;
            //igiaa
            if (maininventory.igiaa > 0.15f && maininventory.igiaa < 0.2f) GAMEPOINTS++;
        }

		if(CLOCK1>1)
		{
            CLOCK1 = 0;
            if (maininventory.igiaa < 0.15f)
			{
			        switch (maininventory.igiaa)
			        {
                        case >11:
                            Invoke("INFLICT_FATIGUE", 0.10f);
                            break;
                        case > 7:
                            Invoke("INFLICT_FATIGUE", 0.5f);
                            break;
                        default:
                            maininventory.fai -= 0.01f;
                            maininventory.poto -= 0.01f;
                            break;
                    }

			}
            /////////////////////////////////////
            if (STAMINA > 2)
            {
                print("b");
                STAMINA = 0;
                INFLICT_FATIGUE();
            }
        }
        if (GAMEPOINTS < 0) GAMEPOINTS = 0;
    }
private void INFLICT_FATIGUE()
	{
        maininventory.fai -= 0.01f;
        maininventory.poto -= 0.01f;

    }
  public float MOD_PET(float a,float b)///DEN VRISKO TO KANONIKO
	{
        var temp = a;

		while (a >= b)           a =a- b;

        if (a > 0 && temp!=a) return a;

        else return -1;
	}
}
