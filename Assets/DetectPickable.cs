using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickable : MonoBehaviour
{
    Pickable playerPickable;
    bool isWithinRange = true;

    private void Awake()
    {
        playerPickable = FindObjectOfType<Pickable>();
    }

    private void Update()
    {
        var dist = Vector2.Distance(transform.position, playerPickable.transform.position);
        if (dist < 1.4f)
        {
            isWithinRange = true;
        }
        else
            isWithinRange = false;
    }
    public bool GetIsWithinRange()
    {
        return isWithinRange;
    }
    public GameObject PickubaleObj()
    {
        return playerPickable.gameObject;
    }
}
