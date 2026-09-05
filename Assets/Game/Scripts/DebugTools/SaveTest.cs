using System;
using Game.Scripts.Core.Saves;
using UnityEngine;
using VContainer;
using YG;

namespace Game.Scripts.DebugTools
{
    public class SaveTest : MonoBehaviour
    {
        private SmartSave _smartSave;

        private void Start()
        {
            print(YG2.saves.CompletedLevels);
        }

        [Inject]
        public void Construct(SmartSave smartSave)
        {
            _smartSave = smartSave;
        }
        
        public void TestRequest()
        {
            _smartSave.Request();
        }

        public void TestImmediately()
        {
            _smartSave.SaveImmediately();
        }
    }
}