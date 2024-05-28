using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAINprotagonist : MonoBehaviour
{
  
    public Rigidbody Rigid;
    public Camera HELP;
    private GameObject picking_object_temp;
    private string picking_object_temp_name;
    [SerializeField] public Sprite mouroimg;
    [SerializeField] private GameObject mouro;
    /// ////////////////////////////////////////////////////////////
    [SerializeField] private GameObject inventorything;
    /// ////////////////////////////////////////////////////////////

    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
    private bool tempswitch = false;
    /// ////////////////////////////////////////////////////////////
    public static List<CONSUME_to_data> consumables = new List<CONSUME_to_data>();
    public static List<CONSUME_to_data> THE_REAL_INVENTORY_4_real= new List<CONSUME_to_data>();

    private void Start()
    {
        consumables.Add(new CONSUME_to_data(10, 0, 0, "mouro", mouroimg));
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventorything.gameObject.SetActive (false);
    }
   
    void Update()
    {
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
                    ODOS_EGO.fai += i.pinas;
                    ODOS_EGO.poto += i.dipsa;
                    ODOS_EGO.igiaa += i.igia;
                }
                else
                {
                  //  print(consumables[0].name);
                  //print(ii);
                    THE_REAL_INVENTORY_4_real.Add(consumables[ii]);
                }
                break;
            }

            ii++;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.tag == "mouro")
        {
            picking_object_temp = collision.gameObject;
            picking_object_temp_name = "mouro";

            
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
