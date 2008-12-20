﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Kelly.Math {
	/// <summary>
	/// Represents a row-major 4x4 matrix.
	/// </summary>
	public partial class Matrix : IEnumerable<float> {
		private Matrix() {
			_values = new float[4, 4];
		}

		public Matrix(IEnumerable<float> values) : this() {
			var index = 0;

			foreach (var element in values) {
				if (index >= 16) {
					throw new ArgumentException("The passed enumerable contains more than 16 elements. A matrix can only be initialized from an enumerable containing 16 elements.");
				}

				this[index / 4, index % 4] = element;
				index++;
			}

			if (index < 16) {
				throw new ArgumentException("The passed enumerable contain less than 16 elements. A matrix can only be initialized from an enumerable containing 16 elements.");
			}
		}

		public Matrix(float[,] values) : this() {
			if (values.GetLength(0) != 4 || values.GetLength(1) != 4) {
				throw new ArgumentException("The passed array does not have the correct dimensions. You can only initialize a matrix from a 4-by-4 array.", "values");
			}

			Array.Copy(values, _values, 16);
		}

		public Matrix(
			float _00, float _01, float _02, float _03,
			float _10, float _11, float _12, float _13,
			float _20, float _21, float _22, float _23,
			float _30, float _31, float _32, float _33) : this() {

			this[0, 0] = _00;
			this[0, 1] = _01;
			this[0, 2] = _02;
			this[0, 3] = _03;

			this[1, 0] = _10;
			this[1, 1] = _11;
			this[1, 2] = _12;
			this[1, 3] = _13;

			this[2, 0] = _20;
			this[2, 1] = _21;
			this[2, 2] = _22;
			this[2, 3] = _23;

			this[3, 0] = _30;
			this[3, 1] = _31;
			this[3, 2] = _32;
			this[3, 3] = _33;
		}

		private readonly float[,] _values;

		public float this[int x, int y] {
			get { return _values[x, y]; }
			private set { _values[x, y] = value; }
		}

		public Matrix Clone() {
			return new Matrix(this);
		}

		public IEnumerator<float> GetEnumerator() {
			for (var row = 0; row < 4; row++) {
				for (var col = 0; col < 4; col++) {
					yield return this[row, col];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
