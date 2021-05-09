using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    Vector3 pos;
    private float x, y, z;
    public Transform rays;
    private RaycastHit F;
    public bool presence = true;

    // Start is called before the first frame update
    void Start()
    {  
        pos = transform.position;
        GetComponent<Collider>().isTrigger = false;
    }
    public void Door()
    {
        Debug.DrawRay(rays.position, transform.forward * 5, Color.green, 1);
        if(Physics.Raycast(rays.position, transform.forward, out F))
        {
            if (F.collider.CompareTag("Player"))
            {
                GetComponent<Collider>().isTrigger = true;
                presence = true;
            } 
        }
    }
    public void DoorClose()
    {
        if (!F.collider.CompareTag("Player"))
        {
            GetComponent<Collider>().isTrigger = false;
            presence = false;
        }
    }
    void OnTriggerStay()
    {
        transform.position = new Vector3(pos.x, pos.y + 3, pos.z);
    }
    void OnTriggerExit()
    {
        transform.position = pos;
    }
}
