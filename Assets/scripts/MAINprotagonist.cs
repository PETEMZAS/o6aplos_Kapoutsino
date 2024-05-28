using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAINprotagonist : MonoBehaviour
{
  
    public Rigidbody Rigid;
    public Camera HELP;
    private GameObject picking_object_temp;
    private string picking_object_temp_name;
    [SerializeField] public Sprite mouroimg, kakomouroimg;
    /// ////////////////////////////////////////////////////////////
    [SerializeField] private GameObject inventorything;
    /// ////////////////////////////////////////////////////////////

    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
    public bool tempswitch;
    /// ////////////////////////////////////////////////////////////
    public static List<CONSUME_to_data> consumables = new List<CONSUME_to_data>();
    public static List<CONSUME_to_data> THE_REAL_INVENTORY= new List<CONSUME_to_data>();

    private void Start()
    {
        consumables.Add(new CONSUME_to_data(10, 0, 0, "mouro", mouroimg));
        consumables.Add(new CONSUME_to_data(2, 0, -10, "kako_mouro", kakomouroimg));

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventorything.gameObject.SetActive (false);
    }
   
    void Update()
    {
        print(consumables[0].quantity);
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

        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {

inventorything.gameObject.SetActive(!inventorything.gameObject.activeSelf);
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
    private void troo_i_apo8ikevo(string nam, bool EAT_KEEP)
    {
        int ii = 0;
        

        foreach (CONSUME_to_data i in consumables)
        {

            if (i.name == nam)
            {
                
                if (EAT_KEEP)
                {
                   
                    ODOS_EGO.Instance.TROO_ODOS(i.pinas, i.dipsa, i.igia);
                }
                else
                {
                    CHECK_INVENTORY_FOR(nam, ii);
                    //THE_REAL_INVENTORY.Add(consumables[ii]);
                }
                break;
            }

            ii++;
        }
    }
    private void CHECK_INVENTORY_FOR(string temp,int tempint)
    {
        bool check = true;
        var temppp = consumables[tempint];
        foreach (CONSUME_to_data i in THE_REAL_INVENTORY)
        {
            if (temp == i.name)
            {
                check = false;
                if (i.quantity < 3)
                {
                    i.quantity++;
                }
                else
                {
                    THE_REAL_INVENTORY.Add(temppp);
                    
                }
                break;


            }
        }
            if (check)
            {
                THE_REAL_INVENTORY.Add(temppp);

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
