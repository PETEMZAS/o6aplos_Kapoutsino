using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAIN : MonoBehaviour
{
  
    public Rigidbody Rigid;
    public Camera HELP;
    //private GameObject picking_object_temp;
    //private string picking_object_temp_name;
   
    /// ////////////////////////////////////////////////////////////
    [SerializeField] private GameObject inventorything;
    /// ////////////////////////////////////////////////////////////


    private Ray laserpointer;
    private RaycastHit laser_HIT;
    public static Transform EGO_IME_EDO;
    public static MAIN Instance;

    /// ////////////////////////////////////////////////////////////
    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
    public bool tempswitch;
    /// ////////////////////////////////////////////////////////////
    public static Dictionary<string,CONSUME_to_data> consumables = new Dictionary<string, CONSUME_to_data>();
    public static Dictionary<string, int> INVENTORY = new Dictionary<string, int>();
    public static List<string> INVENTORY_FR = new List<string>();
    [SerializeField] public Sprite mouroimg, kakomouroimg, skiniIMG, thermosimg, paniimg, ksiloimg, medimg,simeaimg;

    [SerializeField] private GameObject AspriSimea;

	private void Awake()
	{
        EGO_IME_EDO = transform;
        Instance = this;
	}
	private void Start()
    {
        consumables.Add("mouro",new CONSUME_to_data(10, 0, 0,true,false,false, mouroimg));
        consumables.Add("kako_mouro",new CONSUME_to_data(2, 0, -10,true, false, false, kakomouroimg));
        consumables.Add("skini", new CONSUME_to_data(5, -2, -50, true, false, true, skiniIMG));
        consumables.Add("thermos", new CONSUME_to_data(0, 0, 0, true, false, true, thermosimg));
        consumables.Add("ksilo", new CONSUME_to_data(0, 0, 0, true, true, false, ksiloimg));
        consumables.Add("pani", new CONSUME_to_data(0, 0, 0, false, true, false, paniimg));
        consumables.Add("med", new CONSUME_to_data(0, 0, 0, true, false, false, medimg));
        consumables.Add("simea", new CONSUME_to_data(0, 0, 0, false, false, true, simeaimg));


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
       
        /// ////////////////////////////////////////////////////////////
        EGO_IME_EDO = transform;

      laserpointer = new(HELP.transform.position, HELP.transform.forward);


        if (checklaser() =="mouro"|| checklaser() == "kako_mouro" || checklaser() == "skini" || checklaser() == "thermos" || checklaser() == "ksilo" || checklaser() == "pani" || checklaser() == "pani" || checklaser() == "med")
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


		/// ////////////////////////////////////////////////////////////  KINISI
		if (!inventorything.gameObject.activeSelf)
		{
        float mouse = Input.GetAxis("Mouse Y");
            HELP.transform.Rotate(new Vector3(-mouse * MouseSensitivity, 0, 0));
            Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
          
            Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        


        if (Input.GetKeyDown("space") /*&& tempswitch*/)
        {
            Rigid.AddForce(transform.up * JumpForce);
        }

		}
                   
                            if (Input.GetKeyDown(KeyCode.Tab))
                            {

                                inventorything.gameObject.SetActive(!inventorything.gameObject.activeSelf);
                                /// ////////////////////////////////////////////////////////////
           
                                /// ////////////////////////////////////////////////////////////
                                if (inventorything.gameObject.activeSelf) {
                                    Cursor.lockState = CursorLockMode.None;
                                    Cursor.visible = true;
         
                                }
                                else
                                {
                                    Cursor.lockState = CursorLockMode.Locked;
                                    Cursor.visible = false;
              
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
                 
                    ODOS_EGO.Instance.TROO_ODOS(consumables[nam].pinas, consumables[nam].dipsa, consumables[nam].igia);
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


    public void SIMOS()
	{
        var temp = Instantiate(AspriSimea);
        temp.transform.SetParent(this.transform);
        temp.transform.localPosition = new Vector3(0.55f, -0.2f, 1f);   
	}
    
    //private void OnTriggerStay(Collider collision)
    //{
    //    switch (collision.gameObject.tag)
    //    {
    //        case "mouro":
    //            picking_object_temp = collision.gameObject;
    //            picking_object_temp_name = "mouro";
    //            break;
    //        case "kako_mouro":
    //            picking_object_temp = collision.gameObject;
    //            picking_object_temp_name = "kako_mouro";
    //            break;
    //        case "skini":
    //            picking_object_temp = collision.gameObject;
    //            picking_object_temp_name = "skini";
    //            break;

    //    }
       
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    picking_object_temp = null;
    //    picking_object_temp_name = null;
    //}
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "gamoedafos")
        {
            tempswitch = false;

        }
        //picking_object_temp = null;
        //picking_object_temp_name = null;
    }


}
