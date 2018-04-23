

using System;
using System.Threading;

public class Operation {
    Int32 _progress;
    Boolean _started;
    Object l_started = new Object();

    public Int32 Progress {
        get { return _progress; }
        private set { _progress = value; }
    }

    public Boolean Started {
        get { lock (l_started) return _started; }
        private set { lock (l_started) _started = value; }
    }

    public void AsyncStart(Int32 interval) {
        if (Started) return;
        Started = true;
        Progress = 0;
        var t = new Thread(start);
        t.Start(interval);
    }

    void start(Object interval) {
        /*
         * suggest long operations here
         */
        var time = (Int32)interval;
        const Int32 steps = 100;
        var period = time / steps;
        for (int i = 0; i < steps; i++) {
            Thread.Sleep(period);
            Progress++;
        }
        Started = false;
    }
}

