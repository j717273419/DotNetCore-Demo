using System;

namespace AspNetCore.Api.Dapper.Demo.HelloWorld
{
    /// <summary>
    /// ����Ԥ��ʵ����
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// ����
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// ���϶�
        /// </summary>

        public int TemperatureC { get; set; }
        /// <summary>
        /// �����¶�
        /// </summary>

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
