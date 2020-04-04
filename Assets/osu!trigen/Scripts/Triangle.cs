using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace riles.trigen {
    public class Triangle : MonoBehaviour {
        private float speedMultiplier;
        [SerializeField]
        private SpriteRenderer sprite;

        void Update() {
            if (!trigenVariables.Paused) {
                // Move the triangle
                transform.localPosition += trigenVariables.MovementDirection * speedMultiplier * Time.deltaTime;

                if (transform.localPosition.x >= trigenVariables.GeneratorSpace || transform.localPosition.x <= -trigenVariables.GeneratorSpace || transform.localPosition.y >= trigenVariables.GeneratorSpace || transform.localPosition.y <= -trigenVariables.GeneratorSpace) {
                    // Recycle triangle to increase performance and save memory
                    Vector3 position = TriangleSpawner.NewLocation();
                    Vector3 scale = TriangleSpawner.NewScale();

                    transform.localPosition = new Vector3(position.x, position.y, scale.x);
                    transform.localScale = scale;

                    Init();
                }
            }
        }

        public void Init() {
            // Apply speed multiplier
            speedMultiplier = Random.Range(trigenVariables.MinimumSpeedMultiplier, trigenVariables.MaximumSpeedMultiplier);
            // Set color to random tri color
            SetColor(trigenVariables.TriColors[Random.Range(0, trigenVariables.TriColors.Length)]);
        }

        public void SetColor(Color color) {
            float h;
            float s;
            float v;
            float variant = Random.Range(-trigenVariables.ColorVariance, trigenVariables.ColorVariance);

            Color.RGBToHSV(color, out h, out s, out v);
            v += variant;
            sprite.color = Color.HSVToRGB(h, s, v);
        }
    }
}
