using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityCam : MonoBehaviour
{
    private float shotTime = 1;
//    private bool resetting = false;
    public Transform rayEmitter;
      Vector3 pos;
    private RaycastHit hit;
    private Renderer rend;
    bool shot = true;
    GameObject bullet;
    private Collider some;
    public door Door;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(rayEmitter.position, transform.forward, out hit)) {
            if (hit.collider.CompareTag("Player")) {
                rend.material.color = Color.red;
                Debug.DrawRay(rayEmitter.position, transform.forward * 10, Color.red, 1);
                Fire();
            }else {
                rend.material.color = Color.green;
                Debug.DrawRay(rayEmitter.position, transform.forward * 10, Color.green, 1);
            }
        }
        if (Door.presence == true)
        {
            Door.Door();
        } else if (Door.presence == false)
        {
            Door.DoorClose();
        }
    }

    void Fire() {
        if (shot) {
        bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position = rayEmitter.position;
        bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        bullet.AddComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.Impulse);
        bullet.GetComponent<Collider>().isTrigger = false;
        shot = false;
        StartCoroutine(Shot());
         //if (RenderSettings.skybox.HasProperty("_Tint"))
         //{
           //  RenderSettings.skybox.SetColor("_Tint", Color.black);
         //} else if (RenderSettings.skybox.HasProperty("_SkyTint"))
         //{
           //  RenderSettings.skybox.SetColor("_Tint", Color.black);
         //}
        }
    }

    IEnumerator Shot() {
        // Do something
        Debug.Log("I shot player!");
        yield return new WaitForSecondsRealtime(shotTime);
        shot = true;
    }
    void Reset()
    {
    }
    
}
