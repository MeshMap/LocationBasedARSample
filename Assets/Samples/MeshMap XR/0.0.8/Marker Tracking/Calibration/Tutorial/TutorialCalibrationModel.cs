using System;
using UnityEngine;

namespace MeshMap.XR.MarkerTracking.Samples
{
    public class TutorialCalibrationModel : MonoBehaviour
    {
        public static event Action<float> OnXPosDiffChanged;
        public static event Action<float> OnYPosDiffChanged;
        public static event Action<float> OnZPosDiffChanged;
        public static event Action<float> OnXRotDiffChanged;
        public static event Action<float> OnYRotDiffChanged;
        public static event Action<float> OnZRotDiffChanged;

        [SerializeField] private GameObject _content;
        [SerializeField, Range(0.01f, 10f)] private float _increment = 5f;
        private float _posScaler = 0.02f;

        private float _xPosDiff;
        private float _yPosDiff;
        private float _zPosDiff;
        private float _xRotDiff;
        private float _yRotDiff;
        private float _zRotDiff;
        
        private void SetDiff(ref float diff, float value, Action<float> eventCallback)
        {
            if (Mathf.Approximately(diff, value)) return;
            
            diff = value;
            eventCallback?.Invoke(diff);
        }
        
        private float XPosDiff
        {
            get => _xPosDiff;
            set => SetDiff(ref _xPosDiff, value, OnXPosDiffChanged);
        }

        private float YPosDiff
        {
            get => _yPosDiff;
            set => SetDiff(ref _yPosDiff, value, OnYPosDiffChanged);
        }

        private float ZPosDiff
        {
            get => _zPosDiff;
            set => SetDiff(ref _zPosDiff, value, OnZPosDiffChanged);
        }

        private float XRotDiff
        {
            get => _xRotDiff;
            set => SetDiff(ref _xRotDiff, value, OnXRotDiffChanged);
        }

        private float YRotDiff
        {
            get => _yRotDiff;
            set => SetDiff(ref _yRotDiff, value, OnYRotDiffChanged);
        }

        private float ZRotDiff
        {
            get => _zRotDiff;
            set => SetDiff(ref _zRotDiff, value, OnZRotDiffChanged);
        }
        
        private void ResetCalibrationData()
        {
            XPosDiff = 0;
            YPosDiff = 0;
            ZPosDiff = 0;
            XRotDiff = 0;
            YRotDiff = 0;
            ZRotDiff = 0;
        }
        
        public void ResetPrecalibratedState()
        {
            if (!_content) return;
            
            _content.transform.localPosition = Vector3.zero;
            _content.transform.localRotation = Quaternion.identity;
            
            ResetCalibrationData();
        }
        
        private void MoveContent(Vector3 direction)
        {
            _content.transform.Translate(direction * _increment * _posScaler);
        }

        private void RotateContent(Vector3 axis)
        {
            _content.transform.Rotate(axis * _increment);
        }

        public void IncreaseXPosDiff()
        {
            if (!_content) return;
            MoveContent(Vector3.right);
            XPosDiff += _increment;
        }

        public void DecreaseXPosDiff()
        {
            if (!_content) return;
            MoveContent(Vector3.left);
            XPosDiff -= _increment;
        }

        public void IncreaseYPosDiff()
        {
            if (!_content) return;
            MoveContent(Vector3.up);
            YPosDiff += _increment;
        }

        public void DecreaseYPosDiff()
        {
            if (!_content) return;
            MoveContent(Vector3.down);
            YPosDiff -= _increment;
        }

        public void IncreaseZPosDiff()
        {
            if (!_content) return;
            MoveContent(Vector3.forward);
            ZPosDiff += _increment;
        }

        public void DecreaseZPosDiff()
        {
            if (!_content) return;
            MoveContent(Vector3.back);
            ZPosDiff -= _increment;
        }
        
        public void IncreaseXRotDiff()
        {
            if (!_content) return;
            RotateContent(Vector3.right);
            XRotDiff += _increment;
        }

        public void DecreaseXRotDiff()
        {
            if (!_content) return;
            RotateContent(Vector3.left);
            XRotDiff -= _increment;
        }

        public void IncreaseYRotDiff()
        {
            if (!_content) return;
            RotateContent(Vector3.up);
            YRotDiff += _increment;
        }

        public void DecreaseYRotDiff()
        {
            if (!_content) return;
            RotateContent(Vector3.down);
            YRotDiff -= _increment;
        }

        public void IncreaseZRotDiff()
        {
            if (!_content) return;
            RotateContent(Vector3.forward);
            ZRotDiff += _increment;
        }

        public void DecreaseZRotDiff()
        {
            if (!_content) return;
            RotateContent(Vector3.back);
            ZRotDiff -= _increment;
        }
        
        public Vector3 GetPositionData()
        {
            return new Vector3(XPosDiff, YPosDiff, ZPosDiff);
        }

        public Quaternion GetRotationData()
        {
            return Quaternion.Euler(XRotDiff, YRotDiff, ZRotDiff);
        }
    }
}