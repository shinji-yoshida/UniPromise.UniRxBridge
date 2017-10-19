using UniRx;
using System;

namespace UniPromise.UniRxBridge {
	public static class UnitPromise {
		public static Promise<CUnit> Resolved = Promises.Resolved<CUnit>(CUnit.Default);

		public static Promise<CUnit> Rejected(Exception e) {
			return Promises.Rejected<CUnit>(e);
		}

		public static Promise<CUnit> Disposed = Promises.Disposed<CUnit>();
	}
}
