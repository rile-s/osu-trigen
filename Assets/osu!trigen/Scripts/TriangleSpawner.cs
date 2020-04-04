using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace riles.trigen {
    public class TriangleSpawner : MonoBehaviour {
        public Transform triContainer;
        public GameObject triangle;
        [Space]
        public static Transform leftEdge;
        public static Transform rightEdge;

        private float spawnChanceFinal;

        private void Awake() {
            // Get edges
            foreach (Transform child in transform) {
                if (child.name == "LeftEdge") {
                    leftEdge = child;
                } else if (child.name == "RightEdge") {
                    rightEdge = child;
                }
            }
        }

        void Update() {
            // Set rotation for spawner
            transform.localEulerAngles = trigenVariables.GeneratorRotation;

            // Set spawner width
            leftEdge.localPosition = new Vector3(-trigenVariables.GeneratorWidth, -20);
            rightEdge.localPosition = new Vector3(trigenVariables.GeneratorWidth, -20);

            // Check if manager has paused or has reached max tris
            if (trigenVariables.Paused || trigenVariables.TriCount >= trigenVariables.MaxTris) return;

            // Get spawn chance
            spawnChanceFinal = Random.Range(0f, 1f);

            // Check if tri can be spawned
            if (spawnChanceFinal > 1 - trigenVariables.SpawnChance) {
                // Get position and scale
                Vector3 position = NewLocation();
                Vector3 scale = NewScale();
                position.z = scale.x;

                // Create tri and set position and scale
                GameObject go = Instantiate(triangle, triContainer, false);
                go.transform.localPosition = position;
                go.transform.localScale = scale;

                // Init tri
                Triangle tri = go.GetComponent<Triangle>();
                tri.Init();
            }
        }

        // Static method for triangles
        public static Vector3 NewLocation() {
            Vector3 loc = Vector3.Lerp(leftEdge.position, rightEdge.position, Random.Range(0f, 1f));
            loc.z = leftEdge.parent.position.z;
            return loc;
        }

        public static Vector3 NewScale() {
            float scale = Random.Range(trigenVariables.MinimumSize, trigenVariables.MaximumSize);
            return new Vector3(scale, scale);
        }
    }
}
