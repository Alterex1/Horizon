using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class RTSController : MonoBehaviour
{
    public static RTSController Instance { get; private set; }

    public List<ShipUnit> selectedShipUnitList { get; private set; }
    private InputSystem inputSystem;

    public event Action<ShipUnit> OnUnitSelect;
    public event Action OnUnitDeselect;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"There's more than one ShipRTSController {transform}-{Instance}");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        selectedShipUnitList = new List<ShipUnit>();
    }

    private void Start()
    {
        inputSystem = InputSystem.Instance;

        inputSystem.OnCommandAction += InputSystem_OnCommandAction;
    }

    private void InputSystem_OnCommandAction()
    {
        Vector3 moveToPosition = MouseWorld.GetMouseWorldPosition();

        List<Vector3> targetPositionList = GetPositionListAround(moveToPosition, 1f, selectedShipUnitList.Count);

        int targetPositionListIndex = 0;

        foreach (ShipUnit shipUnit in selectedShipUnitList)
        {
            shipUnit.MoveToPosition(targetPositionList[targetPositionListIndex]);
            targetPositionListIndex = (targetPositionListIndex + 1) % targetPositionList.Count;
        }
    }

    public void AddSelectedUnit(ShipUnit shipUnit)
    {
        if (!selectedShipUnitList.Contains(shipUnit))
        {
            selectedShipUnitList.Add(shipUnit);
            OnUnitSelect?.Invoke(shipUnit);
        }
    }

    public void DeselectAll()
    {
        foreach (ShipUnit shipUnit in selectedShipUnitList)
        {
            OnUnitDeselect?.Invoke();
        }
        selectedShipUnitList.Clear();

    }

    private List<Vector3> GetPositionListAround(Vector3 startPosition, float distance, int positionCount)
    {
        List<Vector3> positionList = new List<Vector3>();

        if (positionCount == 1)
        { // If there is only one position, just return the startPosition
            positionList.Add(startPosition);
            return positionList;
        }

        for (int i = 0; i < positionCount; ++i)
        { // Calculate a circle of positions based on positionCount
            float angle = i * (360f / positionCount);
            Vector3 direction = Quaternion.Euler(0, 0, angle) * new Vector3(1, 0);
            Vector3 position = startPosition + direction * distance;
            positionList.Add(position);
        }

        return positionList;
    }
}
