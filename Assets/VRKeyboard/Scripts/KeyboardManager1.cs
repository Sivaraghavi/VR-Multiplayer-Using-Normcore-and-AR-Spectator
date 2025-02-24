
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
