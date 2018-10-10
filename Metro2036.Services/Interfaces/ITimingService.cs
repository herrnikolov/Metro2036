namespace Metro2036.Services.Interfaces
{
    using Metro2036.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITimingService
    {
        Station GetTime(int StantionId);
    }
}
