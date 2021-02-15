using System;

namespace WebApp.DI {
	public interface IOperation {
		string Uid { get; }
	}

	public interface IOperationTransient : IOperation {
	}
	public interface IOperationScoped : IOperation {
	}
	public interface IOperationSingleton : IOperation {
	}

	public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton {
		public string Uid { get; } = Guid.NewGuid().ToString()[^4..];
	}
}
