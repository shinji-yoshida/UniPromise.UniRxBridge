using System;
using UniRx;

namespace UniPromise.UniRxBridge {
	public class SubscribedPromise<T> : Deferred<T> where T : class {
		IDisposable subscription = Disposable.Empty;

		public SubscribedPromise(IObservable<T> source) {
			subscription = source.Take(1).Subscribe(t => this.Resolve(t), e => this.Reject(e), () => this.Dispose());
		}

		public override void Dispose () {
			base.Dispose();
			subscription.Dispose();
		}
	}
}
