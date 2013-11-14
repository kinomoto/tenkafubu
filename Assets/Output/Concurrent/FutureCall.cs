using System;

namespace Tenkafubu.Concurrent
{
	public interface FutureCall<T> : Future<T>
	{
		
		void SetResult(T v);
		void SetError(Exception e);
	}
}

