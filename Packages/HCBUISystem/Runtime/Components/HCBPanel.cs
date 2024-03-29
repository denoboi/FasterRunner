using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace HCB.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class HCBPanel : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        protected CanvasGroup CanvasGroup { get { return (canvasGroup == null) ? canvasGroup = GetComponent<CanvasGroup>() : canvasGroup; } }

        [ValueDropdown("panelList")]
        public string PanelID;


        public UnityEvent OnPanelShown = new UnityEvent();
        public UnityEvent OnPanelHide = new UnityEvent();



        private List<string> panelList
        {
            get { return HCBPanelList.PanelIDs; }
        }

        protected virtual void Awake()
        {
            HCBPanelList.HCBPanels[PanelID] = this;
        }


        [ButtonGroup("PanelVisibility")]
        public virtual void ShowPanel()
        {
            CanvasGroup.alpha = 1;
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
        }

        [ButtonGroup("PanelVisibility")]
        public virtual void HidePanel()
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }

        [ButtonGroup("PanelVisibility")]
        public virtual void TogglePanel()
        {
            if (CanvasGroup.alpha == 0)
                ShowPanel();
            else HidePanel();
        }

    }
}
