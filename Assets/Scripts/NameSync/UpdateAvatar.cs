using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using System.Diagnostics;

namespace Name
{

public class UpdateAvatar : MonoBehaviour
{
        private RealtimeAvatarManager realtimeAvatarManager;
        private RealtimeAvatar realtimeAvatar;
        private string avatarName;

        private void Awake()
        {
            realtimeAvatarManager = GetComponent<RealtimeAvatarManager>();
        }

        private void OnEnable()
        {
            realtimeAvatarManager.avatarCreated += AvatarCreated;
        }

        private void AvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
        {
           if(isLocalAvatar)
            {
                realtimeAvatar = avatar;
            }
        }

        public void SaveLocalPlayerName(TextMeshProUGUI nameField)
        {
            if (nameField != null)
            {
                avatarName = nameField.text;
                realtimeAvatar.GetComponentInChildren<NameSync>().SetText(avatarName);
                UnityEngine.Debug.Log("Success avatarName: " + avatarName);
            }
            else
            {
                UnityEngine.Debug.LogWarning("avatarName is not assigned!");
            }
        }



    }
}
