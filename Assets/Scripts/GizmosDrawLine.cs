using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class GizmosDrawLine: MonoBehaviour
    {
        public float arrowRadius = 2f;
        public Vector3[] squarePoint = new Vector3[]
        {
            new Vector3(-1, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(-1, 1, 0)
        };

        public float snakeLength=10;
        public int snakeSegment=20;
        
 
        [DrawGizmo(GizmoType.Active|GizmoType.Selected,typeof(GizmosDrawLine))]
        private static void DrawLine(GizmosDrawLine drawLine, GizmoType drawType)
        {
            Gizmos.matrix = drawLine.transform.localToWorldMatrix;
            
            //Draw LineStrip
            Gizmos.DrawLineStrip(drawLine.squarePoint,true);
            var next = GetNextReadOnlySpan(drawLine.squarePoint);
            Gizmos.DrawLineStrip(next,false); 
            //Draw LineList
            Gizmos.DrawLineList(GetSnakePoint(drawLine.transform.position,drawLine.snakeLength,drawLine.snakeSegment));
            var radius = drawLine.arrowRadius;
            radius /= 2;
            Gizmos.color = new Color(0, 1, 0, 0.7f);
            //Draw Arror
            Gizmos.DrawLine(Vector3.zero, (Vector3.forward * 2f) * radius);
            Gizmos.DrawLine(2 * radius * Vector3.forward, ((1.5f * radius * Vector3.forward) + 0.5f * radius * Vector3.left));
            Gizmos.DrawLine(2 * radius * Vector3.forward, ((1.5f * radius * Vector3.forward) + 0.5f * radius * Vector3.right));  
        }


        public static Vector3[] GetSnakePoint(Vector3 center,float length,int segment)
        {
            float step=length / segment;
            Vector3[] result = new Vector3[segment];
            Vector3 start = center;
            Vector3 end = center;
            start.z = step - length / 2;
            end.z = step + length / 2;
            Vector3 current = start;

            int index = 0;
            while (current.z<end.z)
            { 
                current.y = Mathf.PerlinNoise1D(current.z/3)*2.2f;
                result[index++] = new Vector3(current.x,current.y,current.z);
                current.z += step;
                Debug.Log($"z{current.z}+y{current.y}");
            }

            return result;
        }
        
        public static Vector3[] GetNextReadOnlySpan(Vector3[] v, float offset = 3)
        {
            Vector3[] newSpawn = new Vector3[v.Length];

            for (var i = 0; i < v.Length; i++)
            {
                newSpawn[i] = v[i] + new Vector3(0, offset, 0);
            }

            return newSpawn;
        }
    }
}