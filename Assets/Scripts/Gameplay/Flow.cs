using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Group8.Base;
using UnityEngine;

namespace Group8.Gameplay
{
    public class Flow : UpdatableBaseObject
    {
        private LineRenderer lineRenderer = null;
        private ParticleSystem particleSystem = null;
        [SerializeField] private float lineAnimateSpeed = 1.75f;

        private Coroutine pouringRoutine = null;
        private Vector3 targetPosition = Vector3.zero;
        private bool isPouring = false;


        public override void BaseObjectAwake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            particleSystem = GetComponentInChildren<ParticleSystem>();
        }

        public override void BaseObjectStart()
        {
            MoveLineToPosition(0, transform.position);
            MoveLineToPosition(1, transform.position);
            
            //Debug.Log(FindEndPoint());
        }

        public override void BaseObjectUpdate()
        {
            if (Input.GetKey(KeyCode.A) && !isPouring)
            {
                Begin();
                isPouring = false;
            }
            else if (isPouring)
            {
                End();
            }
        }

        public void Begin()
        {
            StartCoroutine(UpdateParticle());
            pouringRoutine = StartCoroutine(BeginPouring());
        }

        public void End()
        {
            StopCoroutine(pouringRoutine);
            pouringRoutine = StartCoroutine(EndPouring());
        }

        private IEnumerator BeginPouring()
        {
            while (gameObject.activeSelf)
            {
                targetPosition = FindEndPoint();
                MoveLineToPosition(0, transform.position);
                MoveLineToPosition(1, targetPosition, true);
                yield return null;
            }
        }

        private IEnumerator EndPouring()
        {
            while (true)
            {
                yield return null;
            }
        }

        private IEnumerator UpdateParticle()
        {
            while (gameObject.activeSelf)
            {
                particleSystem.gameObject.transform.position = targetPosition;
                
                particleSystem.gameObject.SetActive(IsHittedGround(1, targetPosition));
                yield return null;
            }
        }
        
        private Vector3 FindEndPoint()
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit);
            return hit.collider ? hit.point : (transform.position + Vector3.down) * 2f;
        }

        private void MoveLineToPosition(int index, Vector3 position, bool isAnimated = false)
        {
            Vector3 currentPoint = lineRenderer.GetPosition(index);
            lineRenderer.SetPosition(index, isAnimated ? Vector3.MoveTowards(currentPoint, position, Time.deltaTime * lineAnimateSpeed): position);
        }

        private bool IsHittedGround(int index, Vector3 targetPosition)
        {
            return lineRenderer.GetPosition(index) == targetPosition;
        }
    }
}

