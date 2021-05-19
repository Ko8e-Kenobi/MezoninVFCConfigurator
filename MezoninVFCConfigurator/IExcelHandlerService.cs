using System.Collections.Generic;

namespace MezoninVFCConfigurator
{
    interface IExcelHandlerService
    {
        void WriteData(Dictionary<int, VFCConfig> data);
        Dictionary<int, VFCConfig> ReadData();
    }
}
