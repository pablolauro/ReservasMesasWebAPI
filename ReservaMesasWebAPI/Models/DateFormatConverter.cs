using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ReservaMesasWebAPI.Models
{
    internal class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            base.DateTimeFormat = format;
        }
    }
}