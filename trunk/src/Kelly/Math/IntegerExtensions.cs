﻿namespace Kelly.Math {
	public static class IntegerExtensions {
		public static bool IsEven(this int value) {
			return value % 2 == 0;
		}

		public static bool IsOdd(this int value) {
			return !value.IsEven();
		}

		public static bool IsEven(this uint value) {
			return value % 2 == 0;
		}

		public static bool IsOdd(this uint value) {
			return !value.IsEven();
		}
	}
}