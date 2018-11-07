namespace Metro2036.Services.Interfaces
{
    using Metro2036.Models;
    using Metro2036.Services.Implementations;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITimingService
    {
        StationTimings GetTime(int StantionId);
    }
}
