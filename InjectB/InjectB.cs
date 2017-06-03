using EasyHook;
using EasyHookTest2;
using System;
using System.Threading;

namespace InjectB
{
    public class InjectDll : IEntryPoint
    {
        private DLLInterface _dllInterface;

        public InjectDll(RemoteHooking.IContext context, string channelName)
        {
            try
            {
                _dllInterface = RemoteHooking.IpcConnectClient<DLLInterface>(channelName);
                _dllInterface.Message(string.Format("Injected: {0}", channelName));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debugger.Launch();
            }
        }

        public void Run(RemoteHooking.IContext context, string channelName)
        {
            try
            {
                while (true)
                {
                    _dllInterface.Message(channelName);
                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                _dllInterface.Message(ex.Message);
            }
        }
    }
}
