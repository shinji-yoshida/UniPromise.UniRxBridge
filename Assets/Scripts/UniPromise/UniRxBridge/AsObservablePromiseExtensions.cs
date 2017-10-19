using UniRx;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UniPromise.UniRxBridge {
	public static class AsObservablePromiseExtensions {
		public static IObservable<T> AsObservable<T>(this Promise<T> promise) where T : class {
			return Observable.Create<T>(observer => promise.Clone ().Done (t => {
				observer.OnNext (t);
				observer.OnCompleted ();
			}).Fail (e => observer.OnError (e)));
		}

		public static IObservable<T> AsObservable<T>(this IEnumerable<Promise<T>> promises) where T : class {
			var clonedPromises = promises.Select(p => p.Clone()).ToList();

			if (clonedPromises.Count == 0)
				return Observable.Empty<T> ();

			return Observable.Create<T>(observer => {
				int doneCount = 0;
				foreach(var each in clonedPromises){
					each
						.Done(t => {
							observer.OnNext(t);
							doneCount++;
							if(doneCount == clonedPromises.Count)
								observer.OnCompleted();
						})
						.Fail(e => observer.OnError(e));
				}
				return new CompositeDisposable(clonedPromises.Select(p => p as IDisposable));
			});
		}
	}
}