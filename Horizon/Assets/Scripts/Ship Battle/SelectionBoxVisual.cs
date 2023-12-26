using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class SelectionBoxVisual : MonoBehaviour
{
    [SerializeField] private GameObject selectionBoxVisualGameObject;

    private InputSystem inputSystem;
    private Vector3 startPosition;

    private void Awake()
    {
        Hide();
    }

    private void Start()
    {
        inputSystem = InputSystem.Instance;

        inputSystem.OnSelectStartedAction += SelectionBoxVisual_OnSelectStartedAction;
        inputSystem.OnSelectReleasedAction += SelectionBoxVisual_OnSelectReleaseAction;

    }

    private void SelectionBoxVisual_OnSelectStartedAction()
    {
        Show();
        startPosition = MouseWorld.GetMouseWorldPosition();

    }

    private void SelectionBoxVisual_OnSelectReleaseAction()
    {
        Hide();
    }

    private void Update()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (inputSystem.IsSelectPressed())
        {
            Vector3 currentMousePosition = MouseWorld.GetMouseWorldPosition();

            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startPosition.x, currentMousePosition.x),
                Mathf.Min(startPosition.y, currentMousePosition.y)
            );

            Vector3 upperRight = new Vector3(
                Mathf.Max(startPosition.x, currentMousePosition.x),
                Mathf.Max(startPosition.y, currentMousePosition.y)
            );

            transform.position = lowerLeft;
            transform.localScale = upperRight - lowerLeft;
        }

    }

    private void Show()
    {
        selectionBoxVisualGameObject.SetActive(true);
    }

    private void Hide()
    {
        selectionBoxVisualGameObject.SetActive(false);
    }
}
