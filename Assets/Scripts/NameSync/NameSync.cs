using UnityEngine;
using Normal.Realtime;
using TMPro;
using System;

namespace Name
{
    public class NameSync : RealtimeComponent<NameSyncModel>
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        protected override void OnRealtimeModelReplaced(NameSyncModel previousModel, NameSyncModel currentModel)
        {
            base.OnRealtimeModelReplaced(previousModel, currentModel);

            if (previousModel != null)
            {
                previousModel.nameDidChange -= NameDidChange;
            }

            if (currentModel != null)
            {
                if (currentModel.isFreshModel)
                {
                    currentModel.name = _textMeshPro.text;
                }

                UpdateName();

                currentModel.nameDidChange += NameDidChange;
            }
        }

        private void UpdateName()
        {
            if (_textMeshPro != null)
            {
                _textMeshPro.text = model.name;
            }
            else
            {
                Debug.LogError("_textMeshPro is not assigned");
            }
        }

        private void NameDidChange(NameSyncModel model, string value)
        {
            UpdateName();
        }

        public void SetText(string name)
        {
            model.name = name;
        }

        private void Awake()
        {
            if (_textMeshPro == null)
            {
                Debug.LogError("_textMeshPro is not assigned in the Inspector");
            }
        }
    }
}
