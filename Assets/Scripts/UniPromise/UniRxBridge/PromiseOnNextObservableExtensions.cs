using UnityEngine;
using System.Collections;
using UniRx;

namespace UniPromise.UniRxBridge {
	public static class PromiseOnNextObservableExtensions {
		public static Promise<T> PromiseOnNext<T>(this IObservable<T> source) where T : class {
			return new SubscribedPromise<T>(source);
		}

		public static Promise<CUnit> PromiseOnNextUnit<T>(this IObservable<T> source) {
			return new SubscribedPromise<CUnit>(source.Select(_ => CUnit.Default));
		}

		public static Promise<CUnit> PromiseOnNext(this IObservable<Unit> source) {
			return new SubscribedPromise<CUnit>(source.Select(_ => CUnit.Default));
		}
	}
}
