# csharp-gc-latency-experiment

C# GC Latency Experiment

> Event tracing for Windows (ETW) provides collect information pertaining to garbage collection. For more information [msdn link](https://msdn.microsoft.com/en-us/library/ff356162.aspx)

Here are the steps in using the tool to get the GC information;

- Start cmd as admin
- Start the application
- Start monitoring `PerfMonitor.exe /process:{your-process-id} start`
- do stuff
- Stop monitoring `PerfMonitor.exe stop`
- Generate report `PerfMonitor.exe GCTime` This command will generate a report you need_
