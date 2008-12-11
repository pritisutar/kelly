using System;
using System.Linq;
using Kelly.Math;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_comparing_two_matrices : EqualitySpecs<Matrix> {
		private static readonly System.Random _rng = new System.Random();
		
		protected override Matrix GetRandomInstance() {
			return new Matrix(
				Enumerable
					.Repeat(0f, 16)
					.Select(x => (float)_rng.NextDouble() * 10f));
		}

		protected override Matrix[] GetRandomInstancesThatAreEqual(int count) {
			var instance = GetRandomInstance();

			var array = new Matrix[count];

			for (var i = 0; i < array.Length; i++) {
				array[i] = instance.Clone();
			}

			return array;
		}
	}
}