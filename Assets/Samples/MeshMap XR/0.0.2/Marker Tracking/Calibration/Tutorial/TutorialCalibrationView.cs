#if (MAGICLEAP) && !(METAQUEST) && !(XREAL)
using System;
using UnityEngine;
using TMPro;

namespace MeshMap.MagicLeap2.Samples.MarkerTracking
{
    public class TutorialCalibrationView: MonoBehaviour
    {
        [Header("Position Texts")]
        [SerializeField] private TextMeshProUGUI _xPosDiffText;
        [SerializeField] private TextMeshProUGUI _yPosDiffText;
        [SerializeField] private TextMeshProUGUI _zPosDiffText;
        
        [Header("Rotation Texts")]
        [SerializeField] private TextMeshProUGUI _xRotDiffText;
        [SerializeField] private TextMeshProUGUI _yRotDiffText;
        [SerializeField] private TextMeshProUGUI _zRotDiffText;
        
        // Store delegate references so we can unsubscribe later
        private Action<float> _xPosDiffChangedListener;
        private Action<float> _yPosDiffChangedListener;
        private Action<float> _zPosDiffChangedListener;
        private Action<float> _xRotDiffChangedListener;
        private Action<float> _yRotDiffChangedListener;
        private Action<float> _zRotDiffChangedListener;
        
        private void Start()
        {
            // Define the delegate lambdas and store them for unsubscribing later
            _xPosDiffChangedListener = (value) => UpdateDiffText(_xPosDiffText, value);
            _yPosDiffChangedListener = (value) => UpdateDiffText(_yPosDiffText, value);
            _zPosDiffChangedListener = (value) => UpdateDiffText(_zPosDiffText, value);
            
            _xRotDiffChangedListener = (value) => UpdateDiffText(_xRotDiffText, value);
            _yRotDiffChangedListener = (value) => UpdateDiffText(_yRotDiffText, value);
            _zRotDiffChangedListener = (value) => UpdateDiffText(_zRotDiffText, value);
            
            // Subscribe to events
            TutorialCalibrationModel.OnXPosDiffChanged += _xPosDiffChangedListener;
            TutorialCalibrationModel.OnYPosDiffChanged += _yPosDiffChangedListener;
            TutorialCalibrationModel.OnZPosDiffChanged += _zPosDiffChangedListener;

            TutorialCalibrationModel.OnXRotDiffChanged += _xRotDiffChangedListener;
            TutorialCalibrationModel.OnYRotDiffChanged += _yRotDiffChangedListener;
            TutorialCalibrationModel.OnZRotDiffChanged += _zRotDiffChangedListener;
        }
        
        private void OnDestroy()
        {
            // Unsubscribe using the stored delegate references
            TutorialCalibrationModel.OnXPosDiffChanged -= _xPosDiffChangedListener;
            TutorialCalibrationModel.OnYPosDiffChanged -= _yPosDiffChangedListener;
            TutorialCalibrationModel.OnZPosDiffChanged -= _zPosDiffChangedListener;

            TutorialCalibrationModel.OnXRotDiffChanged -= _xRotDiffChangedListener;
            TutorialCalibrationModel.OnYRotDiffChanged -= _yRotDiffChangedListener;
            TutorialCalibrationModel.OnZRotDiffChanged -= _zRotDiffChangedListener;
        }
        
        private void UpdateDiffText(TextMeshProUGUI text, float diff)
        {
            // Allow some room for error introduced by floats
            if (diff is < 0.001f and > -0.001f)
            {
                text.text = "0";
            }
            else if (diff > 0)
            {
                text.text = "+" + diff.ToString("F2");
            }
            else
            {
                text.text = diff.ToString("F2");
            }
        }
    }
}
#endif