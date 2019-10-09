using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace DomesticCalculator
{
    public class TimerManager : IDisposable
    {
        private readonly IReadOnlyList<double> _intervals;
        private int _counter;
        private readonly Timer _timer;

        public ConcurrentQueue<string> Results { get; }

        public TimerManager(IReadOnlyList<double> intervals)
        {
            _intervals = intervals;
            _counter = 0;
            Results = new ConcurrentQueue<string>();

            _timer = new Timer();
            _timer.AutoReset = false;
            _timer.Enabled = true;
            _timer.Interval = intervals[_counter];
            _timer.Enabled = false;

            _timer.Elapsed += async (sender, args) => await HandleElapsed();
            _timer.Start();
        }

        public void Dispose() => _timer?.Dispose();

        private async Task HandleElapsed()
        {
            _timer.Stop();

            //execute some job for 100 milliseconds
            await Task.Run(() =>
            {
                if (_counter < _intervals.Count)
                    Results.Enqueue($"{_counter} after {_intervals[_counter]}");
                Thread.Sleep(100);
            });

            if (_counter < _intervals.Count)
            {
                //see recommendations - avoid double event generation
                _timer.Enabled = true;
                _timer.Interval = _intervals[_counter];
                Interlocked.Increment(ref _counter);
                _timer.Enabled = false;

                _timer.Start();
            }

            //otherwise stop execution
        }

    }
}