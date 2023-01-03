using System;

namespace CompilerGenerated
{
	[Serializable]
	internal sealed class _0024adaptor_0024___0024_MoveNext_0024callable0_00241622_73___0024Action_00240
	{
		protected ___0024_MoveNext_0024callable0_00241622_73__ _0024from;

		public _0024adaptor_0024___0024_MoveNext_0024callable0_00241622_73___0024Action_00240(___0024_MoveNext_0024callable0_00241622_73__ from)
		{
			_0024from = from;
		}

		public void Invoke(string key, int value)
		{
			_0024from(key);
		}

		public static Action<string, int> Adapt(___0024_MoveNext_0024callable0_00241622_73__ from)
		{
			return new _0024adaptor_0024___0024_MoveNext_0024callable0_00241622_73___0024Action_00240(from).Invoke;
		}
	}
}
