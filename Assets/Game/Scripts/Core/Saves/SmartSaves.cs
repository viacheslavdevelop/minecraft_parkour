using System;
using Game.Scripts.Core.Data;
using Unity.VisualScripting;
using UnityEngine;
using VContainer.Unity;
using YG;

namespace Game.Scripts.Core.Saves
{
    public class SmartSave : ITickable, IDisposable
    {
        public event Action OnSaved;
        
        private readonly float _debounceSeconds = 0.5f;
        private readonly float _maxDelaySeconds = 5f;
        
        private bool _pending;
        private float _firstRequestTime;
        private float _lastRequestTime;

        public bool HasPending => _pending;

        private SmartSave(GameConfig gameConfig)
        {
            _debounceSeconds = gameConfig.DebounceSeconds;
            _maxDelaySeconds = gameConfig.MaxDelaySeconds;
            
            _pending = false;
            _firstRequestTime = 0f;
            _lastRequestTime = 0f;
            OnSaved = null;
        }

        public void Request()
        {
            float now = Time.unscaledTime;

            if (!_pending)
            {
                _pending = true;
                _firstRequestTime = now;
            }

            _lastRequestTime = now;
        }

        public void SaveImmediately()
        {
            _pending = true;
            Flush();
        }

        private void Flush()
        {
            if (!_pending)
                return;

            if (!YG2.isSDKEnabled)
                return;

            _pending = false;
            YG2.SaveProgress();
            OnSaved?.Invoke();
        }

        public void Cancel() => _pending = false;

        public void Tick()
        {
            if (!_pending)
                return;

            float now = Time.unscaledTime;

            bool streamEnded = now - _lastRequestTime >= _debounceSeconds;
            bool maxDelayReached = now - _firstRequestTime >= _maxDelaySeconds;

            if (streamEnded || maxDelayReached)
            {
                Flush();
            }
        }

        public void Dispose()
        {
            SaveImmediately();
        }
    }
}