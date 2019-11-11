using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vuforia
{

    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class MoreTarget : MonoBehaviour, ITrackableEventHandler 
    {

        UnityEngine.UI.Image image;
        GameObject btn;


        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES


        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            image = GameObject.Find("FindBottleImage").GetComponent<UnityEngine.UI.Image>();
            btn = GameObject.Find("ConfirmButton");


            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this); //注册追踪事件
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS


        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS


        #region PRIVATE_METHODS

        
        private void OnTrackingFound()
        {
            print(this.gameObject.name + ":find");

            image.enabled = false;
            ConfirmButtonControl.Show();
            
        }


        private void OnTrackingLost()
        {
            print(this.gameObject.name + ":lost");
            ConfirmButtonControl.Hide();
            
            image.enabled = true;
            

        }

        #endregion // PRIVATE_METHODS

       
    }
}

