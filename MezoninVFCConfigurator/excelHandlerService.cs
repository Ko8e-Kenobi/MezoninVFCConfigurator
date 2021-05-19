using System;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Collections.Generic;
namespace MezoninVFCConfigurator
{
    class excelHandlerService : IExcelHandlerService
    {
        IWorkbook myWorkbook;
        ISheet mySheet;
        public excelHandlerService()
        {
            try
            {
                Console.WriteLine($"{System.IO.Directory.GetCurrentDirectory()}\\Resources\\Config.xlsx");
                myWorkbook = new XSSFWorkbook($"{System.IO.Directory.GetCurrentDirectory()}\\Resources\\Config.xlsx");
                mySheet = myWorkbook.GetSheet("1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void WriteData(Dictionary<int, VFCConfig> data)
        {

        }

        public Dictionary<int, VFCConfig> ReadData()
        {   
            Dictionary<int, VFCConfig> vfcConfigs = new Dictionary<int, VFCConfig>();

            foreach(IRow row in mySheet)
            {
                try
                {
                    List<ICell> cells = new List<ICell>();
                    const int CELLS_NUMBER = 13;
                    for (int i = 0; i < CELLS_NUMBER; i++)
                    {
                        cells.Add(row.GetCell(i));
                    }

                    var currentConfig = new VFCConfig
                    {
                        Id = Convert.ToUInt16(cells[0].NumericCellValue),
                        IpAddress = cells[1].StringCellValue,
                        ModbusAddress = Convert.ToByte(cells[2].NumericCellValue),
                        VfcTag = cells[3].StringCellValue,
                        RRS = Convert.ToUInt16(cells[4].NumericCellValue),
                        NPL = Convert.ToUInt16(cells[5].NumericCellValue),
                        CHCF = Convert.ToUInt16(cells[6].NumericCellValue),
                        ACC = Convert.ToUInt16(cells[7].NumericCellValue),
                        DEC = Convert.ToUInt16(cells[8].NumericCellValue),
                        AIV1 = Convert.ToUInt16(cells[9].NumericCellValue),
                        ATR = Convert.ToUInt16(cells[10].NumericCellValue),
                        TAR = Convert.ToUInt16(cells[11].NumericCellValue),
                        RSF = Convert.ToUInt16(cells[12].NumericCellValue)
                    };
                    vfcConfigs.Add(currentConfig.Id, currentConfig);
                }
                catch (Exception)
                {
                    Console.WriteLine("Not correct row or header");
                }
            }
            return vfcConfigs;
        }

    }
}
