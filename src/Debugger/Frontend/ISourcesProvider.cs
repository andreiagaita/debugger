using System;
using System.Collections.Generic;

namespace Debugger
{
	public interface ISourcesProvider
	{
		int Port { get; set; }
		string Path { get; set; }
		IList<string> Sources { get; }

		event Action<string> FileChanged;
		event Action SourcesChanged;

		void StartRefreshingSources ();
		void StopRefreshingSources ();
	}
}
