using System;
using System.Globalization;

namespace Date
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //var data = new DateTime();
            //var data = DateTime.Now;
            // var data = DateTime.Now;

            // var formatado = String.Format("{0: yyy}", data);

            // Console.WriteLine(data);
            // Console.WriteLine(data.Year);
            // Console.WriteLine(data.Month);
            // Console.WriteLine(data.Day);
            // Console.WriteLine(data.Hour);
            // Console.WriteLine(data.Minute);
            // Console.WriteLine("");
            // Console.WriteLine(formatado);

            /*CULTURE INFO*/
            // var pt = new CultureInfo("pt-PT");
            // var br = new CultureInfo("pt-BR");
            // var en = new CultureInfo("en-UK");
            // var atual = System.Globalization.CultureInfo.CurrentCulture;
            // var ac = CultureInfo.CurrentCulture;

            // Console.WriteLine($"atual value: {atual}");
            // Console.WriteLine($"ac value: {ac}");

            /*TIMEZONE - UTC*/
            // var dateTimeUtc = DateTime.UtcNow; //pega a data GMT padrão
            // Console.WriteLine($"Timezone GMT: {dateTimeUtc}");
            // Console.WriteLine($"Timezone Brasil: {dateTimeUtc.ToLocalTime()}");

            // var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
            // Console.WriteLine($" Timezone Australia: {timezoneAustralia}");

            // var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, timezoneAustralia); //converte de UTC para um timeZone específico

            // var timeZones = TimeZoneInfo.GetSystemTimeZones();
            // foreach (var timezone in timeZones)
            // {
            //     Console.WriteLine($"Timezone Id: {timezone.Id}");
            //     Console.WriteLine($"Timezone: {timezone}");
            //     Console.WriteLine($"Convertendo todos timezone de UTC para {timezone.Id}: {TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, timezone)}");
            //     Console.WriteLine("-------------------------------------");
            // }

            /*TIME SPAN(DADO SENSÍVEL) - DIA, HORA, MINUTO, SEGUNDOS, MILISEGUNDOS E NANOSECUNDOS*/
            var timeSpan = new TimeSpan(1, 5, 0, 0);
            int a = Convert.ToInt32(10);
            Console.WriteLine($"timeSpan value: {timeSpan.Add(new TimeSpan(TimeSpan.TicksPerHour))}");

        }
    }
}
