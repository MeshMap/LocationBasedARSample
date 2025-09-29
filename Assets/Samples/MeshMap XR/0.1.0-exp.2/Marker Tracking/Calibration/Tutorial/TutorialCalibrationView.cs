// Copyright 2025 MeshMap Labs Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSES-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permission and
// limitations under the License.

using System;
using UnityEngine;
using TMPro;

namespace MeshMap.XR.Samples.MarkerTracking
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