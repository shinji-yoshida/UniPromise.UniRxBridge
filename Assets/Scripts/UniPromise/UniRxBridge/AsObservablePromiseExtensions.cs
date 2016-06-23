using UniRx;


namespace UniPromise.UniRxBridge {
	public static class AsObservablePromiseExtensions {
		public static IObservable<T> AsObservable<T>(this Promise<T> promise) {
			return Observable.Create<T>(observer => promise.Clone ().Done (t => {
				observer.OnNext (t);
				observer.OnCompleted ();
			}).Fail (e => observer.OnError (e)));
		}
	}
}