using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private ShipUnit shipUnit;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Hide();
    }

    private void Start()
    {
        RTSController.Instance.OnUnitSelect += RTSController_OnUnitSelect; 
        RTSController.Instance.OnUnitDeselect += RTSController_OnUnitDeselect; 
    }

    private void RTSController_OnUnitSelect(ShipUnit shipUnit)
    {
        if (shipUnit == this.shipUnit)
        {
            Show();
        }

    }

    private void RTSController_OnUnitDeselect()
    {
        Hide();
    }

    private void Show()
    {
        spriteRenderer.enabled = true;
    }

    private void Hide()
    {
        spriteRenderer.enabled = false;
    }

}
