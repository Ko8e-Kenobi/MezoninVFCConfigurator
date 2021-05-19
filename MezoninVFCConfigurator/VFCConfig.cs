namespace MezoninVFCConfigurator 
{
    /// <summary>
    /// Конфигурация частотного преобразователя
    /// </summary>
    class VFCConfig
    {
        public ushort Id { get; set; }
        public byte ModbusAddress { get; set; }
        public string IpAddress { get; set; }
        public string VfcTag { get; set; }
        public ushort RRS, NPL, CHCF, ACC, DEC, AIV1, ATR, TAR, RSF;

    }
}
