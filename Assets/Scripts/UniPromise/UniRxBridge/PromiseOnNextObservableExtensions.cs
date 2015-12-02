using UnityEngine;
using System.Collections;
using UniRx;

namespace UniPromise.UniRxBridge {
	public static class PromiseOnNextObservableExtensions {
		public static Promise<T> PromiseOnNext<T>(this IObservable<T> source) {
			return new SubscribedPromise<T>(source);
		}
	}
}
