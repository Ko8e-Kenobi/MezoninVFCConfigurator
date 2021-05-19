using System.Collections.Generic;

namespace MezoninVFCConfigurator
{
    interface IVFCsModbusService
    {
        void WriteData(Dictionary<int, VFCConfig> data);
        Dictionary<int, VFCConfig> ReadData();
    }
}
