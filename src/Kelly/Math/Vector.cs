﻿using System.Diagnostics;

namespace Kelly.Math {
	[DebuggerDisplay("({X}, {Y}, {Z})")]
	public struct Vector {
		public Vector(float x, float y, float z) {
			_x = x;
			_y = y;
			_z = z;
		}

		public readonly float _x, _y, _z;

		public float X {
			get { return _x; }
		}

		public float Y {
			get { return _y; }
		}

		public float Z {
			get { return _z; }
		}

		public float SquaredLength {
			get { return DotProduct(this, this); }
		}

		public float Length {
			get { return (float)System.Math.Sqrt(SquaredLength); }
		}

		public static float DotProduct(Vector x, Vector y) {
			return x.X * y.X
				 + x.Y * y.Y
				 + x.Z * y.Z;
		}

		public Vector Scale(float s) {
			return new Vector(X * s, Y * s, Z * s);
		}

		public bool IsUnit {
			get { return SquaredLength == 1.0f; }
		}

		public Vector ToUnit() {
			return Scale(1.0f / Length);
		}
	}
}