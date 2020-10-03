using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Group8.Base;
using Group8.Gameplay;

namespace Group8.Gameplay
{
    public class FlowStarter : UpdatableBaseObject
    {
        public Transform origin = null;
        public GameObject flowPrefab = null;

        private bool isFlowing = false;
        private Flow currentFlow = null;

        public override void BaseObjectUpdate()
        {
            bool inputCheck = Input.GetKey(KeyCode.A);

            if (isFlowing != inputCheck)
            {
                isFlowing = inputCheck;

                if (isFlowing)
                {
                    StartFlow();
                }
                else
                {
                    EndFlow();
                }
            }
        }

        private void StartFlow()
        {
            currentFlow = CreateFlow();
            currentFlow.Begin();
        }

        private void EndFlow()
        {
            currentFlow.End();
            currentFlow = null;
        }

        private Flow CreateFlow()
        {
            GameObject flowObject = Instantiate(flowPrefab, origin.position, Quaternion.identity, transform);
            return flowObject.GetComponent<Flow>();
        }
    }

}
