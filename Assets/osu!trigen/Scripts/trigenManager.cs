using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace riles.trigen {
    public class trigenManager : MonoBehaviour {
        public bool paused = false;
        public int triCount = 0;
        public int maxTris = 150;
        [Header("General Settings")]
        public Vector3 movementDirection = new Vector3(0, 2, 0);
        [Header("Spawner Settings")]
        public float generatorSpace = 25;
        public float generatorWidth = 15;
        [Range(0f, 1f)]
        [Tooltip("Chance that a triangle will spawn each frame.")]
        public float spawnChance = 0.4f;
        [Header("Tri Settings")]
        public float minimumSpeedMultiplier = 0.5f;
        public float maximumSpeedMuliplier = 1.5f;
        [Space]
        public float minimumSize = 0.02f;
        public float maximumSize = 0.4f;
        [Space]
        [Range(0f, 1f)]
        public float colorVariance = 0.1f;

        [Header("Cosmetic")]
        public Color[] triColors = new Color[1] { new Color(255, 124, 216) };
        public Color backgroundColor = new Color(65, 65, 65);

        void Update() {
            // Pause if there is no movement
            if (movementDirection == Vector3.zero) {
                paused = true;
            }

            triCount = GameObject.FindGameObjectsWithTag("Triangle").Length;

            trigenVariables.Paused = paused;
            trigenVariables.TriCount = triCount;
            trigenVariables.MaxTris = maxTris;
            trigenVariables.MovementDirection = movementDirection;
            trigenVariables.GeneratorRotation = new Vector3(0, 0, -Angle(movementDirection));
            trigenVariables.GeneratorSpace = generatorSpace;
            trigenVariables.GeneratorWidth = generatorWidth;
            trigenVariables.SpawnChance = spawnChance;
            trigenVariables.MinimumSpeedMultiplier = minimumSpeedMultiplier;
            trigenVariables.MaximumSpeedMultiplier = maximumSpeedMuliplier;
            trigenVariables.MinimumSize = minimumSize;
            trigenVariables.MaximumSize = maximumSize;
            trigenVariables.ColorVariance = colorVariance;
            trigenVariables.TriColors = triColors;
            trigenVariables.BackgroundColor = backgroundColor;
        }

        // I suck at math
        // thank you person on the internet
        public float Angle(Vector2 p_vector2) {
            if (p_vector2.x < 0) {
                return 360 - (Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg * -1);
            } else {
                return Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
            }
        }
    }
}
