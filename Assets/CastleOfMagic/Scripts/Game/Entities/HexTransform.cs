﻿using System;
using CastleMagic.Util.Hex;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace CastleMagic.Game.Entites {

    /// <summary>
    /// Represents any object that has a position on the board and cannot be passed through.
    /// </summary>
    [ExecuteInEditMode]
    public class HexTransform : MonoBehaviour {

        public UnityAction<PositionDelta> OnPositionChanged;

        private HexCoord position;
        public HexCoord Position {
            get {
                return position;
            }
            set {
                HexCoord old = position;
                position = value;
                if (plane != null) {
                    transform.position = plane.HexToWorldPosition(position);
                }
                OnPositionChanged.Invoke(new PositionDelta(old, position));
            }
        }
        private HexPlane plane;

        private void Start() {
            plane = GameObject.FindWithTag("Board").GetComponent<HexPlane>();
        }

    }

}
