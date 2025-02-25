/*using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Controls the steps in the in coaching card.
    /// </summary>
    public class StepManager : MonoBehaviour
    {
        [Serializable]
        class Step
        {
            [SerializeField]
            public GameObject stepObject;

            [SerializeField]
            public string buttonText;
        }

        [SerializeField]
        public TextMeshProUGUI m_StepButtonTextField;

        [SerializeField]
        List<Step> m_StepList = new List<Step>();

        int m_CurrentStepIndex = 0;

        public void Next()
        {
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);
            m_CurrentStepIndex = (m_CurrentStepIndex + 1) % m_StepList.Count;
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }
    }
}
*/

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Controls the steps in the in coaching card.
    /// </summary>
    public class StepManager : MonoBehaviour
    {
        [Serializable]
        class Step
        {
            [SerializeField]
            public GameObject stepObject;

            [SerializeField]
            public string buttonText;
        }

        [SerializeField]
        public TextMeshProUGUI m_StepButtonTextField;

        [SerializeField]
        List<Step> m_StepList = new List<Step>();

        int m_CurrentStepIndex = 0;

        // Method for handling the "Next" button (Create Button)
        public void Next()
        {
            // Hide current step
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);

            // Move to the next step in the list (looping back to start if needed)
            m_CurrentStepIndex = (m_CurrentStepIndex + 1) % m_StepList.Count;

            // Show the next step
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);

            // Update the button text for the new step
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }

        // Method for handling the "Join" button (Go to the step after the current step)
        public void Join()
        {
            // Hide current step
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);

            // Move to the step after the next one (skipping 1 step ahead)
            m_CurrentStepIndex = Mathf.Min(m_CurrentStepIndex + 2, m_StepList.Count - 1);

            // Show the new step
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);

            // Update the button text for the new step
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }

        // Method to go back to the Create step (back to the first step)
        public void BackToCreate()
        {
            // Go to the first step (index 0)
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);
            m_CurrentStepIndex = 0;
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }

        // Method to go back to the Join step (back to the step after "Create")
        public void BackToJoin()
        {
            // Go to the second step (index 1), assuming "Join" starts after "Create"
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);
            m_CurrentStepIndex = Mathf.Min(m_CurrentStepIndex, 1);  // Make sure we don't go back before the second step
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }
    }
}

