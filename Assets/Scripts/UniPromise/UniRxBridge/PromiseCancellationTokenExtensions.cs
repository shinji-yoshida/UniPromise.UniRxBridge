using UniRx;
using System;
using System.Threading;

namespace UniPromise.UniRxBridge {
	public static class PromiseCancellationTokenExtensions {
		public static Promise<T> DisposeIfCanceled<T>(this CancellationToken cancellationToken, Func<Promise<T>> func) where T : class {
			if (cancellationToken.IsCancellationRequested)
				return Promises.Disposed<T> ();
			return func ();
		}
	}
}
