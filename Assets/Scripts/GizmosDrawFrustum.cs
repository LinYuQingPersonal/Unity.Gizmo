using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GizmosDrawFrustum : MonoBehaviour
    {
        public Vector3 center;
        public float fov;
        public float max;
        public float min;
        public float aspect;
        private void OnDrawGizmos()
        {
            // ?Gizmos.matrix.SetTRS(transform.position,transform.rotation,transform.lossyScale);
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawFrustum(center,fov,max,min,aspect);
            
        }
    }
}