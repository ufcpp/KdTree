﻿using System;

namespace KdTree
{
	public partial class Point<T, TArithmetic>
		where T : IComparable<T>, IEquatable<T>
		where TArithmetic : struct, IArithmetic<T>
	{
		private static readonly TArithmetic _arithmetic = default;

		public partial class Dimention<TArray, TArrayAccessor>
			where TArray : struct, IFixedArray<T>
			where TArrayAccessor : struct, IFixedArrayAccessor<T, TArray>
		{
			private static readonly TArrayAccessor _accessor = default;

			public partial class Metric<TMetric>
				where TMetric : struct, IMetric<T, TArray>
			{
			}

			public class Euclidean : Metric<EuclideanMetric<T, TArray, TArrayAccessor, TArithmetic>> { }
			public class Manhattan : Metric<ManhattanMetric<T, TArray, TArrayAccessor, TArithmetic>> { }
			public class Chebyshev : Metric<ChebyshevMetric<T, TArray, TArrayAccessor, TArithmetic>> { }
		}

		public class _1 : Dimention<Fixed1<T>.Array, Fixed1<T>> { }
		public class _2 : Dimention<Fixed2<T>.Array, Fixed2<T>> { }
		public class _3 : Dimention<Fixed3<T>.Array, Fixed3<T>> { }
		public class _4 : Dimention<Fixed4<T>.Array, Fixed4<T>> { }
	}

	public class Int : Point<int, IntArithmetic> { }
	public class Short : Point<short, ShortArithmetic> { }
	public class Long : Point<long, LongArithmetic> { }
	public class Float : Point<float, FloatArithmetic>
	{
		public class Geo : Dimention<GeoLocation, GeoLocationAccessor>
		{
			public class Geodesics : Metric<GeoMetic> { }
		}
	}
	public class Double : Point<double, DoubleArithmetic> { }
}