using System;

namespace AspNetCore.Api.Dapper.Demo.HelloWorld
{
    /// <summary>
    /// 天气预报实体类
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 摄氏度
        /// </summary>

        public int TemperatureC { get; set; }
        /// <summary>
        /// 华氏温度
        /// </summary>

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
