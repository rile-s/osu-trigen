using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace riles.trigen {
    public class Background : MonoBehaviour {
        public enum BackgroundType { UI, Sprite }
        public BackgroundType backgroundType;

        private Image image;
        private SpriteRenderer sprite;

        void Awake() {
            if (backgroundType == BackgroundType.UI) {
                image = GetComponent<Image>();
            } else {
                sprite = GetComponent<SpriteRenderer>();
            }
        }

        void Update() {
            if (backgroundType == BackgroundType.UI) {
                image.color = trigenVariables.BackgroundColor;
            } else {
                sprite.color = trigenVariables.BackgroundColor;
            }
        }
    }
}
