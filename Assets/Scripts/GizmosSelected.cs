using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GizmosSelected: MonoBehaviour
    {
        /// <summary>
        /// 不论何时,都会显示蓝色球
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color=Color.blue;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawSphere(Vector3.zero,1);
        }

        /// <summary>
        /// 仅当选中时,显示红色虚线球
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireSphere(Vector3.zero,1);
        }
    }
}