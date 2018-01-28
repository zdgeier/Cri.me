using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRayHitShowInfo : MonoBehaviour {
    private Transform child;

    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    void HitByRay()
    {
        bool isActive = transform.GetChild(0).gameObject.activeSelf;
        transform.GetChild(0).gameObject.SetActive(!isActive);
        transform.GetChild(1).gameObject.SetActive(isActive);
    }
}
