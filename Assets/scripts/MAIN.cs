using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAIN : MonoBehaviour
{
  
    public Rigidbody Rigid;
    public Camera HELP;
    private GameObject picking_object_temp;
    private string picking_object_temp_name;
    [SerializeField] public Sprite mouroimg, kakomouroimg,skiniIMG;
    /// ////////////////////////////////////////////////////////////
    [SerializeField] private GameObject inventorything;
    /// ////////////////////////////////////////////////////////////

    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
    public bool tempswitch;
    /// ////////////////////////////////////////////////////////////
    public static Dictionary<string,CONSUME_to_data> consumables = new Dictionary<string, CONSUME_to_data>();
    public static Dictionary<string, int> INVENTORY = new Dictionary<string, int>();
    public static List<string> INVENTORY_FR = new List<string>();
   
    

    private void Start()
    {
        consumables.Add("mouro",new CONSUME_to_data(10, 0, 0,true,false,false, mouroimg));
        consumables.Add("kako_mouro",new CONSUME_to_data(2, 0, -10,true, false, false, kakomouroimg));
        consumables.Add("skini", new CONSUME_to_data(5, -2, -50, true, false, true, skiniIMG));


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventorything.gameObject.SetActive (false);
        
    }
   
    void Update()
    {
		//if (GameManager.state == GameManager.GAMESTATE.chilling)
		//{
            /// ////////////////////////////////////////////////////////////
            float mouse = Input.GetAxis("Mouse Y");
            HELP.transform.Rotate(new Vector3(-mouse * MouseSensitivity, 0, 0));
            Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
            // if(tempswitch )///prosorini allagi
            // {
            Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
            // }


            if (Input.GetKeyDown("space") /*&& tempswitch*/)
            {
                            Rigid.AddForce(transform.up * JumpForce);

                            /// ////////////////////////////////////////////////////////////
                            /// 
                            if (Input.GetKeyDown(KeyCode.R))
                        {
                            if (picking_object_temp != default)
                            {
                                if (picking_object_temp != null)
                                {
                                    // SALAMALEKOUM.GetComponent<NERDEMOJI>().FUCKME();
                                    Destroy(picking_object_temp.gameObject);
                                    troo_i_apo8ikevo(picking_object_temp_name, true);
                                    picking_object_temp = null;
                                    picking_object_temp_name = null;
                                }
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            if(picking_object_temp != null)
                            {
                            Destroy(picking_object_temp.gameObject);
                            troo_i_apo8ikevo(picking_object_temp_name, false);
                            picking_object_temp = null;
                            picking_object_temp_name = null;

                            }
                        }
            }

		//} 
                            if (Input.GetKeyDown(KeyCode.Tab))
                            {

                                inventorything.gameObject.SetActive(!inventorything.gameObject.activeSelf);
                                /// ////////////////////////////////////////////////////////////
           
                                /// ////////////////////////////////////////////////////////////
                                if (inventorything.gameObject.activeSelf) {
                                    Cursor.lockState = CursorLockMode.None;
                                    Cursor.visible = true;
             //   GameManager.Instance.Update_STATE(GameManager.GAMESTATE.in_inventory);
                                }
                                else
                                {
                                    Cursor.lockState = CursorLockMode.Locked;
                                    Cursor.visible = false;
               // GameManager.Instance.Update_STATE(GameManager.GAMESTATE.chilling);
            }
                            }

    }
    private void troo_i_apo8ikevo(string nam, bool EAT_KEEP)
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
    
    private void OnTriggerStay(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "mouro":
                picking_object_temp = collision.gameObject;
                picking_object_temp_name = "mouro";
                break;
            case "kako_mouro":
                picking_object_temp = collision.gameObject;
                picking_object_temp_name = "kako_mouro";
                break;
            case "skini":
                picking_object_temp = collision.gameObject;
                picking_object_temp_name = "skini";
                break;

        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        picking_object_temp = null;
        picking_object_temp_name = null;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "gamoedafos")
        {
            tempswitch = false;

        }
        picking_object_temp = null;
        picking_object_temp_name = null;
    }


}
