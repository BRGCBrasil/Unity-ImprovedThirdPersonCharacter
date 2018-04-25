using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace improvedthpc.controller {
    [RequireComponent(typeof(Animator))]
    public class ImprovedTHPC : MonoBehaviour {
        
        #region Private Var's
        private bool m_Crouch;
        private float HorizontalInputValue;
        private float VerticalInputValue;
        private Animator PlayerAnimator;
        #endregion
        private void Start()
        {            
            PlayerAnimator = gameObject.GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            //this is defined as the input is mobile or computer
            #region Set Input 
#if !MOBILE_INPUT
            HorizontalInputValue = Input.GetAxis("Horizontal");
            VerticalInputValue = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.LeftControl))
            {
                m_Crouch = true;
            }
            else
            {
                m_Crouch = false;
            }
#else
            HorizontalInputValue = CrossPlatformInputManager.GetAxis("Horizontal");
            VerticalInputValue = CrossPlatformInputManager.GetAxis("Vertical");
#endif
            #endregion
            //this will set the motion on the animator
            #region Movement
            PlayerAnimator.SetFloat("Forward", VerticalInputValue);
            PlayerAnimator.SetFloat("Turn", HorizontalInputValue);
            PlayerAnimator.SetBool("Crouch", m_Crouch);
            #endregion
        }
    }
}
