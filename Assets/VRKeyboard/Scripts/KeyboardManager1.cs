/*
using UnityEngine;
using TMPro;

namespace VRKeyboard.Utils
{
    public class KeyboardManager1 : MonoBehaviour
    {
        public bool isUppercase = false;
        public int maxInputLength;
        public TMP_InputField inputText; // Update this to TMP_InputField

        public Transform keys;

        private string Input
        {
            get { return inputText.text; }
            set { inputText.text = value; }
        }
        private Key[] keyList;
        private bool capslockFlag;

        void Awake()
        {
            keyList = keys.GetComponentsInChildren<Key>();
        }

        void Start()
        {
            foreach (var key in keyList)
            {
                key.OnKeyClicked += GenerateInput;
            }
            capslockFlag = isUppercase;
            CapsLock();
        }

        public void Backspace()
        {
            if (Input.Length > 0)
            {
                Input = Input.Remove(Input.Length - 1);
            }
        }

        public void Clear()
        {
            Input = "";
        }

        public void CapsLock()
        {
            foreach (var key in keyList)
            {
                if (key is Alphabet)
                {
                    key.CapsLock(capslockFlag);
                }
            }
            capslockFlag = !capslockFlag;
        }

        public void Shift()
        {
            foreach (var key in keyList)
            {
                if (key is Shift)
                {
                    key.ShiftKey();
                }
            }
        }

        public void GenerateInput(string s)
        {
            if (Input.Length > maxInputLength) { return; }
            Input += s;
        }
    }
}
*/

using UnityEngine;
using TMPro;

namespace VRKeyboard.Utils
{
    public class KeyboardManager1 : MonoBehaviour
    {
        public bool isUppercase = false;
        public int maxInputLength;
        public TMP_InputField inputText; // Update this to TMP_InputField
        public Transform keys;

        private string Input
        {
            get { return inputText.text; }
            set { inputText.text = value; }
        }
        private Key[] keyList;
        private bool capslockFlag;

        void Awake()
        {
            if (inputText == null)
            {
                Debug.LogError("inputText is not assigned in the Inspector");
            }

            if (keys == null)
            {
                Debug.LogError("keys is not assigned in the Inspector");
            }
            else
            {
                keyList = keys.GetComponentsInChildren<Key>();
                if (keyList.Length == 0)
                {
                    Debug.LogError("No keys found in children of 'keys' Transform");
                }
            }
        }

        void Start()
        {
            if (keyList != null)
            {
                foreach (var key in keyList)
                {
                    key.OnKeyClicked += GenerateInput;
                }
            }

            capslockFlag = isUppercase;
            CapsLock();
        }

        public void Backspace()
        {
            if (Input.Length > 0)
            {
                Input = Input.Remove(Input.Length - 1);
            }
        }

        public void Clear()
        {
            Input = "";
        }

        public void CapsLock()
        {
            if (keyList != null)
            {
                foreach (var key in keyList)
                {
                    if (key is Alphabet)
                    {
                        key.CapsLock(capslockFlag);
                    }
                }
            }
            capslockFlag = !capslockFlag;
        }

        public void Shift()
        {
            if (keyList != null)
            {
                foreach (var key in keyList)
                {
                    if (key is Shift)
                    {
                        key.ShiftKey();
                    }
                }
            }
        }

        public void GenerateInput(string s)
        {
            if (inputText != null && Input.Length <= maxInputLength)
            {
                Input += s;
            }
            else if (inputText == null)
            {
                Debug.LogError("inputText is null");
            }
        }
    }
}
