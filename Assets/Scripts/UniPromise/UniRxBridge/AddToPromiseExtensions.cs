using UnityEngine;
using UniRx;
using System.Collections.Generic;
using System;

namespace UniPromise.UniRxBridge {
	public static class AddToPromiseExtensions {
		public static Promise<T> AddTo<T>(this Promise<T> promise, ICollection<IDisposable> container) {
			if(promise.IsPending)
				UniRx.DisposableExtensions.AddTo(promise, container);

			return promise;
		}

		public static Promise<T> AddTo<T>(this Promise<T> promise, GameObject gameObject) {
			if(promise.IsPending)
				UniRx.DisposableExtensions.AddTo(promise, gameObject);

			return promise;
		}
		
		public static Promise<T> AddTo<T>(this Promise<T> promise, Component component) {
			if(promise.IsPending)
				UniRx.DisposableExtensions.AddTo(promise, component);

			return promise;
		}
	}
}
