using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
	public class StringsDictionary
	{
		private List<Bucket> _buckets = new();
		private double _fill;

		private int _power;

		public void StringsDictionaryStart(int power)
		{
			_power = power;
			_buckets = SetBuckets();
		}

		public void Add(string element, string value)
		{
			var i = Convert.ToInt32(Math.Abs(ConvertToHash(element) % _power));
			if (!_buckets[i].Visited)
				_fill += 1 / Convert.ToDouble(_power);
			_buckets[i].Add(new KeyValuePair(element, value));
			if (_fill > 0.6)
			{
				_power = _power * 10;
				_buckets = SetBuckets();
			}
		}

		public void Remove(string element)
		{
			var i = Convert.ToInt32(Math.Abs(ConvertToHash(element) % _power));
			_buckets[i].RemoveByKey(element);
		}

		public void Get(string element)
		{
			var i = Convert.ToInt32(Math.Abs(ConvertToHash(element) % _power));
			var result = _buckets[i].GetItemWithKey(element).Value;
			if (result != null) Console.WriteLine(result);
		}

		private List<Bucket> SetBuckets()
		{
			var pureBuckets = new List<Bucket>();
			for (var i = 0; i < _power; i++) pureBuckets.Add(new Bucket());

			_fill = 0;
			foreach (var bucket in _buckets)
				if (bucket.Visited)
				{
					var i = Convert.ToInt32(Math.Abs(ConvertToHash(bucket.First.Pair.Key) % _power));
					pureBuckets[i] = bucket;
				}

			return pureBuckets;
		}

		private long ConvertToHash(string key)
		{
			return key.GetHashCode();
		}
	}
}