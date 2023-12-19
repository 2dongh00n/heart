using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using zSpace.Core.Input;


namespace zSpace.Core.Samples
{

    public class StylusPenbutton : MonoBehaviour
    {
        ZStylus stylus;

        private void Start()
        {
            stylus = GameObject.FindObjectOfType<ZStylus>();
        }

        private void Update()
        {
            // check if a button is presently held down on any given update frame
            bool buttonPressed_0 = stylus.GetButton(0);
            bool buttonPressed_1 = stylus.GetButton(1);
            bool buttonPressed_2 = stylus.GetButton(2);

            // check if a button was pressed on this frame
            bool buttonDown_0 = stylus.GetButtonDown(0);
            bool buttonDown_1 = stylus.GetButtonDown(1);
            bool buttonDown_2 = stylus.GetButtonDown(2);

            // check if a button was released on this frame
            bool buttonUp_0 = stylus.GetButtonUp(0);
            bool buttonUp_1 = stylus.GetButtonUp(1);
            bool buttonUp_2 = stylus.GetButtonUp(2);
        }
    }
}