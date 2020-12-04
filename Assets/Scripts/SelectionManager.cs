using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private string selectableTag = "Selectable";
    private Material originalMaterial;
    
    private Transform _lastObject;

    void Update()
    {
        if (_lastObject != null)
        {
            var selectionRenderer = _lastObject.GetComponent<Renderer>();
            selectionRenderer.material = originalMaterial;
            _lastObject = null;
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectedObject = hit.transform;
            var selectionRenderer = selectedObject.GetComponent<Renderer>();
            originalMaterial = selectionRenderer.material;
            if (selectedObject.CompareTag((selectableTag)))
            {
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                } 
                _lastObject = selectedObject;
            }
        }
    }
}
