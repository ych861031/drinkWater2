using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

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
            UserInfo.scanNum = Int32.Parse(this.gameObject.name.Split('_')[1])-1;
            print(UserInfo.scanNum);
            GameObject.Find("detectNum").GetComponent<Text>().text = UserInfo.scanNum.ToString();
            print("set ar tree");
            UserInfo.SetARTree();

            image.enabled = false;
            ConfirmButtonControl.Show();
            
        }


        private void OnTrackingLost()
        {
            print(this.gameObject.name + ":lost");
            ConfirmButtonControl.Hide();

            GameObject.Find("detectNum").GetComponent<Text>().text = "None";
            image.enabled = true;

            GameObject.Find("score").GetComponent<Text>().text = "None";


        }

        #endregion // PRIVATE_METHODS


    }
}

