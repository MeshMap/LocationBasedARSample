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

using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MeshMap.XR.Samples.MarkerTracking
{
    public class TutorialCalibrationController : MonoBehaviour
    {
        [Header("Position Buttons")]
        [SerializeField] private Button _xPosIncreaseButton;
        [SerializeField] private Button _xPosDecreaseButton;
        [SerializeField] private Button _yPosIncreaseButton;
        [SerializeField] private Button _yPosDecreaseButton;
        [SerializeField] private Button _zPosIncreaseButton;
        [SerializeField] private Button _zPosDecreaseButton;
        
        [Header("Rotation Buttons")]
        [SerializeField] private Button _xRotIncreaseButton;
        [SerializeField] private Button _xRotDecreaseButton;
        [SerializeField] private Button _yRotIncreaseButton;
        [SerializeField] private Button _yRotDecreaseButton;
        [SerializeField] private Button _zRotIncreaseButton;
        [SerializeField] private Button _zRotDecreaseButton;
        
        [Header("Reset Button")]
        [SerializeField] private Button _resetButton;
        
        [Inject] private TutorialCalibrationModel _tutorialCalibrationModel;

        private void Start()
        {
            _xPosIncreaseButton.onClick.AddListener(_tutorialCalibrationModel.IncreaseXPosDiff);
            _xPosDecreaseButton.onClick.AddListener(_tutorialCalibrationModel.DecreaseXPosDiff);
            _yPosIncreaseButton.onClick.AddListener(_tutorialCalibrationModel.IncreaseYPosDiff);
            _yPosDecreaseButton.onClick.AddListener(_tutorialCalibrationModel.DecreaseYPosDiff);
            _zPosIncreaseButton.onClick.AddListener(_tutorialCalibrationModel.IncreaseZPosDiff);
            _zPosDecreaseButton.onClick.AddListener(_tutorialCalibrationModel.DecreaseZPosDiff);
            
            _xRotIncreaseButton.onClick.AddListener(_tutorialCalibrationModel.IncreaseXRotDiff);
            _xRotDecreaseButton.onClick.AddListener(_tutorialCalibrationModel.DecreaseXRotDiff);
            _yRotIncreaseButton.onClick.AddListener(_tutorialCalibrationModel.IncreaseYRotDiff);
            _yRotDecreaseButton.onClick.AddListener(_tutorialCalibrationModel.DecreaseYRotDiff);
            _zRotIncreaseButton.onClick.AddListener(_tutorialCalibrationModel.IncreaseZRotDiff);
            _zRotDecreaseButton.onClick.AddListener(_tutorialCalibrationModel.DecreaseZRotDiff);
            
            _resetButton.onClick.AddListener(_tutorialCalibrationModel.ResetPrecalibratedState);
        }

        private void OnDestroy()
        {
            _xPosIncreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.IncreaseXPosDiff);
            _xPosDecreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.DecreaseXPosDiff);
            _yPosIncreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.IncreaseYPosDiff);
            _yPosDecreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.DecreaseYPosDiff);
            _zPosIncreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.IncreaseZPosDiff);
            _zPosDecreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.DecreaseZPosDiff);
            
            _xRotIncreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.IncreaseXRotDiff);
            _xRotDecreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.DecreaseXRotDiff);
            _yRotIncreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.IncreaseYRotDiff);
            _yRotDecreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.DecreaseYRotDiff);
            _zRotIncreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.IncreaseZRotDiff);
            _zRotDecreaseButton.onClick.RemoveListener(_tutorialCalibrationModel.DecreaseZRotDiff);
            
            _resetButton.onClick.RemoveListener(_tutorialCalibrationModel.ResetPrecalibratedState);
        }
    }
}