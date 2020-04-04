using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace riles.trigen {
    public class LimitVisualizer : MonoBehaviour {
        private void OnDrawGizmos() {
            Gizmos.color = new Color(1, 0, 0, 1);
            Gizmos.DrawWireCube(transform.position, new Vector3(trigenVariables.GeneratorSpace, trigenVariables.GeneratorSpace) * 2);
        }
    }
}
