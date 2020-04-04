using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace riles.trigen {
    public static class trigenVariables {
        public static bool Paused { get; internal set; }
        public static int TriCount { get; internal set; }
        public static int MaxTris { get; internal set; }
        public static Vector3 MovementDirection { get; internal set; }

        // Spawner variables
        public static Vector3 GeneratorRotation { get; internal set; }
        public static float GeneratorSpace { get; internal set; }
        public static float GeneratorWidth { get; internal set; }
        public static float SpawnChance { get; internal set; }

        // Triangle variables
        public static float MinimumSpeedMultiplier { get; internal set; }
        public static float MaximumSpeedMultiplier { get; internal set; }

        public static float MinimumSize { get; internal set; }
        public static float MaximumSize { get; internal set; }

        public static float ColorVariance { get; internal set; }

        // Colors
        public static Color[] TriColors { get; internal set; }
        public static Color BackgroundColor { get; internal set; }
    }
}
