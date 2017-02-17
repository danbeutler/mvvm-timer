using System;

using GalaSoft.MvvmLight.Messaging;

namespace Dbe.Timer.SL.Helpers
{
    public static class AppMessages
    {
        enum MessageTypes
        {
            /// <summary>
            /// Nachricht wird verwendet, wenn der Timer gefeuert wird.
            /// </summary>
            TimerChanged,
       }

        public static class TimerChangedMessage
        {
            public static void Send(object argument = null)
            {
                Messenger.Default.Send(argument, MessageTypes.TimerChanged);
            }

            public static void Register(object recipient, Action<object> action)
            {
                Messenger.Default.Register(recipient, MessageTypes.TimerChanged, action);
            }
        }
    }
}
