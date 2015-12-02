using UniRx;
using System;

namespace UniPromise.UniRxBridge {
	public static class UnitPromise {
		public static Promise<Unit> Resolved = Promises.Resolved<Unit>(Unit.Default);

		public static Promise<Unit> Rejected(Exception e) {
			return Promises.Rejected<Unit>(e);
		}

		public static Promise<Unit> Disposed = Promises.Disposed<Unit>();
	}
}
