using System;
using System.Collections.Generic;
namespace MezoninVFCConfigurator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            excelHandlerService configService = new excelHandlerService();
            Dictionary<int, VFCConfig> fullVFCConfig = configService.ReadData();

            foreach (KeyValuePair <int, VFCConfig> item in fullVFCConfig)
            {
                Console.WriteLine($"{item.Value.VfcTag}: id = {item.Value.Id}, ip = {item.Value.IpAddress}, slaveId = {item.Value.ModbusAddress}, " +
                    $"par1 = {item.Value.RRS}, par2 = {item.Value.NPL}, par3 = {item.Value.CHCF}, par4 = {item.Value.ACC}");
            }

            VFCsModbusService vfdsModbusService = new VFCsModbusService();
            vfdsModbusService.WriteData(fullVFCConfig);
            Console.ReadLine();
        }
    }
}
