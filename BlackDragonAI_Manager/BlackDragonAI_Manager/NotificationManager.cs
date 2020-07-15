using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace BlackDragonAI_Manager
{
    public class NotificationManager
    {
        public const int SecondsToShowNotification = 4;
        public event Action<string> SuccessMessageNeedsToBeShown;
        public event Action<string> SuccessMessageNeedsToBeHidden;
        public event Action<string> FailureMessageNeedsToBeShown;
        public event Action FailureMessageNeedsToBeHidden;

        private List<Timer> _timers = new List<Timer>();

        public void SetSuccessNotification(string message)
        {
            SuccessMessageNeedsToBeShown?.Invoke(message);
            CreateTimer(() => SuccessMessageNeedsToBeHidden?.Invoke(message));
        }

        public void SetFailureNotification(string message)
        {
            FailureMessageNeedsToBeShown?.Invoke(message);
            CreateTimer(() => FailureMessageNeedsToBeHidden?.Invoke());
        }

        // TIMER SHOULD HIDE IT AGAIN, SO FIRST SHOW EVENT THAN LATER HIDE EVENT

        private void CreateTimer(Action elapsedEvent)
        {
            var timer = new Timer(SecondsToShowNotification * 1000)
            {
                AutoReset = false
            };
            timer.Elapsed += (sender, args) => ElapsedTimerEventHandler(timer, elapsedEvent);
            _timers.Add(timer);
            timer.Start();
        }

        private void ElapsedTimerEventHandler(Timer timer, Action elapsedEvent)
        {
            elapsedEvent();
            _timers.Remove(timer);
        }
    }
}
