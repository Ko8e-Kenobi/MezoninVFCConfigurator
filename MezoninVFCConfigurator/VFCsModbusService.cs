using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using NModbus;
namespace MezoninVFCConfigurator
{
    class VFCsModbusService : IVFCsModbusService
    {
        const ushort NPL_ADDRESS = 4100,
                        RRS_ADDRESS = 11106,
                        CHCF_ADDRESS = 8402,
                        ACC_ADDRESS = 9002,
                        DEC_ADDRESS = 9003,
                        AIV1_ADDRESS = 5282,
                        ATR_ADDRESS = 7123,
                        TAR_ADDRESS = 7124,
                        RSF_ADDRESS = 7125;
                        
        public void WriteData(Dictionary<int, VFCConfig> data)
        {
            var factory = new ModbusFactory();

            foreach (var item in data)
            {
                using (TcpClient modbusTCPClient = new TcpClient(item.Value.IpAddress, 502))
                using (IModbusMaster vfd = factory.CreateMaster(modbusTCPClient))
                {   
                    try
                    {
                        ushort[] RRS = vfd.ReadHoldingRegisters(item.Value.ModbusAddress, RRS_ADDRESS, 1);
                        ushort[] NPL = vfd.ReadHoldingRegisters(item.Value.ModbusAddress, NPL_ADDRESS, 1);
                        ushort[] CHCF = vfd.ReadHoldingRegisters(item.Value.ModbusAddress, CHCF_ADDRESS, 1);
                        ushort[] ACC = vfd.ReadHoldingRegisters(item.Value.ModbusAddress, ACC_ADDRESS, 1);
                        ushort[] DEC = vfd.ReadHoldingRegisters(item.Value.ModbusAddress, DEC_ADDRESS, 1);
                        ushort[] AIV1 = vfd.ReadHoldingRegisters(item.Value.ModbusAddress, AIV1_ADDRESS, 1);
                        ushort[] ATR = vfd.ReadHoldingRegisters(item.Value.ModbusAddress, ATR_ADDRESS, 1);
                        ushort[] TAR = vfd.ReadHoldingRegisters(item.Value.ModbusAddress, TAR_ADDRESS, 1);
                        ushort[] RSF = vfd.ReadHoldingRegisters(item.Value.ModbusAddress, RSF_ADDRESS, 1);
                        Console.WriteLine($"RRS: {RRS[0]}, NPL: {NPL[0]}, CHCF: {CHCF[0]}, ACC: {ACC[0]}, DEC: {DEC[0]}, AIV1: {AIV1[0]}, ATR: {ATR[0]}, TAR: {TAR[0]}, RSF: {RSF[0]}");
                        //vfd.WriteSingleRegister(item.Value.ModbusAddress, RRS_ADDRESS, item.Value.RRS);
                        //vfd.WriteSingleRegister(item.Value.ModbusAddress, NPL_ADDRESS, item.Value.NPL);
                        //vfd.WriteSingleRegister(item.Value.ModbusAddress, CHCF_ADDRESS, item.Value.CHCF);
                        //vfd.WriteSingleRegister(item.Value.ModbusAddress, ACC_ADDRESS, item.Value.ACC);
                        //vfd.WriteSingleRegister(item.Value.ModbusAddress, DEC_ADDRESS, item.Value.DEC);
                        //vfd.WriteSingleRegister(item.Value.ModbusAddress, AIV1_ADDRESS, item.Value.AIV1);
                        //vfd.WriteSingleRegister(item.Value.ModbusAddress, ATR_ADDRESS, item.Value.ATR);
                        //vfd.WriteSingleRegister(item.Value.ModbusAddress, TAR_ADDRESS, item.Value.TAR);
                        //vfd.WriteSingleRegister(item.Value.ModbusAddress, RSF_ADDRESS, item.Value.RSF);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //throw;
                    }
                }
            }
        }

       

        public Dictionary<int, VFCConfig> ReadData()
        {
            Dictionary<int, VFCConfig> temp = new Dictionary<int, VFCConfig>();
            return temp;
        }
    }
}
