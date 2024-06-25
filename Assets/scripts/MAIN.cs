using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAIN : MonoBehaviour
{
  
    public Rigidbody Rigid;
    public Camera CAMERA__;
    //private GameObject picking_object_temp;
    //private string picking_object_temp_name;
   
    /// ////////////////////////////////////////////////////////////
    [SerializeField] private GameObject inventorything;
    /// ////////////////////////////////////////////////////////////

    /// ////////////////////////////////////////////////////////////
    private Ray laserpointer;
    private RaycastHit laser_HIT;
    public static Transform EGO_IME_EDO;
    public static MAIN Instance;
    /// ////////////////////////////////////////////////////////////
    //TO gamemanager ine edo giati den doulevan ta funtions otan itan se ksexoristo script
    public static int state=1;
    /// <summary>
    /// 1= exploring 
    /// 2= inventory
    /// 3= deploy
    /// </summary>

    public void Update_STATE(int state_in_int)
    {

        switch (state_in_int)
        {
            case 1:
                state = 1;
                break;
            case 2:
                state = 2;
                break;
            case 3:
                state = 3;
                break;

        }
    }
    private string DEPLOYING_NAME;

    /// ////////////////////////////////////////////////////////////
    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
    public bool tempswitch;
    /// ////////////////////////////////////////////////////////////
    public static Dictionary<string,CONSUME_to_data> consumables = new Dictionary<string, CONSUME_to_data>();
    public static Dictionary<string, int> INVENTORY = new Dictionary<string, int>();
    public static List<string> INVENTORY_FR = new List<string>();
    [SerializeField] public Sprite mouroimg, kakomouroimg, filoimg, thermosimg, paniimg, ksiloimg, medimg,skiniimg, thermosimg2;

    [SerializeField] private GameObject SKINI,BOUKALI;
    private GameObject tempobj=default;

	private void Awake()
	{
        EGO_IME_EDO = transform;
        Instance = this;
	}
	private void Start()
    {
        consumables.Add("mouro",new CONSUME_to_data(10, 0, 0,true,false,false, mouroimg));
        consumables.Add("kako_mouro",new CONSUME_to_data(2, 0, -10,true, false, false, kakomouroimg));
        consumables.Add("thermos", new CONSUME_to_data(0, 0, 0, false, false, true, thermosimg));
        consumables.Add("ksilo", new CONSUME_to_data(0, 0, 0, true, true, false, ksiloimg));
        consumables.Add("pani", new CONSUME_to_data(0, 0, 0, false, true, false, paniimg));
        consumables.Add("med", new CONSUME_to_data(0, 0, 30, true, false, false, medimg));
        consumables.Add("skini", new CONSUME_to_data(0, 0, 0, false, false, true, skiniimg));
        consumables.Add("thermos_nero", new CONSUME_to_data(0,10, 0, true, true, false, thermosimg2));
        consumables.Add("filo", new CONSUME_to_data(0, 0, -2, true, true, false, filoimg));


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventorything.gameObject.SetActive (false);



        

    }
    /// /////////////////////////////////////////////////////////////// ////////////////////////////////////////////////////////////
    private string checklaser()
	{
		if (Physics.Raycast(laserpointer,out laser_HIT))
        return laser_HIT.collider.gameObject.tag;
        
        return default;
	}
    private float dis_laser()
	{
        if (Physics.Raycast(laserpointer, out laser_HIT))              return Vector3.Distance(transform.position, laser_HIT.collider.gameObject.transform.position);
      
        return default;
    }
    private GameObject objecthit()
	{
        if (Physics.Raycast(laserpointer, out laser_HIT))            return laser_HIT.collider.gameObject;

        return default;
    }
    /// /////////////////////////////////////////////////////////////// ////////////////////////////////////////////////////////////
    void Update()
    {

        /// ////////////////////////////////////////////////////////////   /// ////////////////////////////////////////////////////////////
        //  LASER
        ///  /// ////////////////////////////////////////////////////////////   /// ////////////////////////////////////////////////////////////
        EGO_IME_EDO = transform;

      laserpointer = new(CAMERA__.transform.position, CAMERA__.transform.forward); 


        if ((checklaser() =="mouro"|| checklaser() == "kako_mouro" || checklaser() == "skini" || checklaser() == "thermos" || checklaser() == "ksilo" || checklaser() == "pani" || checklaser() == "pani" || checklaser() == "med" || checklaser() == "filo") &&(state==1))
		{
            //AN SIMADEVIS KATI INTERACTABLE
            if (dis_laser() < 3)//AN SIMADEVIS KATI pou ine koda
            {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        var tempname = checklaser();
                        Destroy(objecthit());
                        troo_i_apo8ikevo(tempname, false);
                    }

                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        var tempname = checklaser();
                        Destroy(objecthit());
                        troo_i_apo8ikevo(tempname, true);
                    }
            }

        }

        /// ////////////////////////////////////////////////////////////   /// ////////////////////////////////////////////////////////////
        //  KINISI
        ///  /// ////////////////////////////////////////////////////////////   /// ////////////////////////////////////////////////////////////
        if/*(!inventorything.gameObject.activeSelf)*/ (state!=2)

        {
        float mouse = Input.GetAxis("Mouse Y");
            CAMERA__.transform.Rotate(new Vector3(-mouse * MouseSensitivity, 0, 0));
            Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
          
            Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        


        if (Input.GetKeyDown("space") /*&& tempswitch*/)
        {
            Rigid.AddForce(transform.up * JumpForce);
        }

		}
        /// ////////////////////////////////////////////////////////////   /// ////////////////////////////////////////////////////////////
        /// INVENTORY
        ///    /// ////////////////////////////////////////////////////////////   /// ////////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Tab))
                   {

                                inventorything.gameObject.SetActive(!inventorything.gameObject.activeSelf);
                                /// ////////////////////////////////////////////////////////////
                            
                                /// ////////////////////////////////////////////////////////////
                                if (inventorything.gameObject.activeSelf) {
                                    Cursor.lockState = CursorLockMode.None;
                                    Cursor.visible = true;
                             Update_STATE(2);
                                }
                                else
                                {
                                    Cursor.lockState = CursorLockMode.Locked;
                                    Cursor.visible = false;
                            Update_STATE(1);
                                }
                     }
		/// ////////////////////////////////////////////////////////////   /// ////////////////////////////////////////////////////////////
		//  DEPLOY
		///  /// ////////////////////////////////////////////////////////////   /// ////////////////////////////////////////////////////////////
		if (state == 3)
		{
            Vector3 worldPosition=default;
            laserpointer = new(CAMERA__.transform.position, CAMERA__.transform.forward);
                if (Physics.Raycast(laserpointer, out laser_HIT))    worldPosition = laser_HIT.point;

			switch (DEPLOYING_NAME)
			{
                case "skini":
            tempobj.transform.position = worldPosition;
                                if (Input.GetMouseButtonDown(0))
                                {
                                    state = 1;
                                    var temp = Instantiate(tempobj);
                                    temp.transform.position = tempobj.transform.position;
                                    Destroy(tempobj);
                                }
                                else if(Input.GetMouseButtonDown(1))
			                    {
                                    state = 1;
                                    Destroy(tempobj);
                                    troo_i_apo8ikevo(DEPLOYING_NAME, false);
                                    DEPLOYING_NAME = null;
                                }
                    break;
                case "thermos":
                    if (Input.GetMouseButtonDown(0)&&laser_HIT.collider.gameObject.tag=="nero")
                    {
                        state = 1;
                        troo_i_apo8ikevo("thermos_nero", false);
                        troo_i_apo8ikevo("thermos_nero", false);
                        troo_i_apo8ikevo("thermos_nero", false);
                        Destroy(tempobj);
                    }
                    else if (Input.GetMouseButtonDown(1))
                    {
                        state = 1;
                        Destroy(tempobj);
                        troo_i_apo8ikevo(DEPLOYING_NAME, false);
                        DEPLOYING_NAME = null;
                    }
                    break;
			}       


        }


    }
   
    public void troo_i_apo8ikevo(string nam, bool EAT_KEEP)
    {
        int ii = 0;
        

        foreach ( var i in consumables)
        {

            if (i.Key==nam)
            {
                
                if (EAT_KEEP)
                {
                 
                    maininventory.instance.TROO_ODOS(consumables[nam].pinas, consumables[nam].dipsa, consumables[nam].igia);
                }
                else
                {
					if (INVENTORY.ContainsKey(nam))
					{
                        INVENTORY[nam]++;
                        INVENTORY_FR.Add(nam);
                    }
					else
					{
                    INVENTORY.Add(nam, 1);
					}
                    maininventory.instance.REFRESH_IN();
                }
                break;
            }

            ii++;
        }
    }


    public void DEPLOYING_THING(string dep)
	{
        state = 3;
        DEPLOYING_NAME = dep;
        if(dep=="skini") tempobj =Instantiate(SKINI);

        if(dep=="thermos")
		{
            tempobj = Instantiate(BOUKALI);
            tempobj.transform.SetParent (this.transform);
            tempobj.transform.localPosition = new Vector3(0, 0, 1.3f);
		}

    }
    
  
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "gamoedafos")
        {
            tempswitch = false;

        }
       
    }


}
