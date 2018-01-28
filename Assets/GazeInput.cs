using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInput : MonoBehaviour {

    public GameObject map;

	// Use this for initialization
	void Start () {
        QualitySettings.antiAliasing = 4;
        OVRTouchpad.Create();
        OVRTouchpad.TouchHandler += HandleTouchHandler;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("h"))
        {
            hideBuildings();
        }
	}

    void HandleTouchHandler(object sender, System.EventArgs e)
    {
        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, fwd, out hit))
                hit.transform.SendMessage("HitByRay");
        }

        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Up)
        {
            hideBuildings();
        }
    }

    private void hideBuildings()
    {
        for (int i = 0; i < map.transform.childCount; i++) {
            bool active = map.transform.GetChild(i).GetChild(0).gameObject.activeSelf;
            map.transform.GetChild(i).GetChild(0).gameObject.SetActive(!active);
        }
    }
}
