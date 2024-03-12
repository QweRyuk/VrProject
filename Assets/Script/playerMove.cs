using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerMove : MonoBehaviour
{
    public Camera mainCam;
    public float interactDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractionRay();


    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactDistance))
        {
            IInteractvle interactvle = hit.collider.GetComponent<IInteractvle>();
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                interactvle.Interact();
            }
        }
    }
}
