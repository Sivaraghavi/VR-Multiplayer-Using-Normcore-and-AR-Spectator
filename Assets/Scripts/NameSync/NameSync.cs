using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;
using System;

namespace Name
{
    public class NameSync: RealtimeComponent<NameSyncModel> {
        [SerializeField] private TextMeshPro _textMeshPro;

        protected override void OnRealtimeModelReplaced(NameSyncModel previousModel, NameSyncModel currentModel)
        {
            base.OnRealtimeModelReplaced(previousModel, currentModel);

            if (previousModel != null)
            {
                previousModel.nameDidChange -= NameDidChange;
            }

            if (currentModel != null)
            {
                if(currentModel.isFreshModel)
                {
                    currentModel.name = _textMeshPro.text;
                }

                UpdateName();

                currentModel.nameDidChange += NameDidChange;
            }
        }

        private void UpdateName()
        {
            _textMeshPro.text = model.name;
        }

        private void NameDidChange(NameSyncModel model, string value)
        {
            UpdateName();
        }

        public void SetText(string name)
        {
            model.name = name;
        }
    }

}