using UnityEngine;
using UnityEngine.InputSystem;
using MeshMap.XR.MarkerTracking;

namespace MeshMap.LocationBasedARSample
{
    public class ToggleMarkerVisualsWithInput : ToggleHints
    {
        [SerializeField, Tooltip("The input action to toggle visuals.")] private InputActionProperty _throwActionProperty;

        [SerializeField] private bool _visible = true;
        
        private void Awake()
        {
            _throwActionProperty.action.performed += Toggle;
        }

        private void OnDestroy()
        {
            _throwActionProperty.action.performed -= Toggle;
        }

        private void Toggle(InputAction.CallbackContext context)
        {
            SetHintsVisible(!_visible);
            _visible = !_visible;
        }
    }
}
