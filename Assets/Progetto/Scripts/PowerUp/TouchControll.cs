using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControll : MonoBehaviour {

    private List<GameObject> touchList = new List<GameObject>();
    RaycastHit hit;
    private GameObject[] touchesOld;

    void Update()
    {
        touchesOld = new GameObject[touchList.Count];
        touchList.CopyTo(touchesOld);
        touchList.Clear();

        if (Input.GetMouseButton(0)||Input.GetMouseButtonDown(0)||Input.GetMouseButtonUp(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                 GameObject recipient = hit.transform.gameObject;
                 touchList.Add(recipient);
                 recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
            }  
        }
    }

}
