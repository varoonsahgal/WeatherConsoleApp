using System;
using System.Threading.Tasks;

namespace WeatherConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var weatherService = new WeatherService();

            Console.Write("Enter city name: ");
            var city = Console.ReadLine();

            try
            {
                var weatherData = await weatherService.GetWeatherAsync(city);

                // Split the response into components
                var parts = weatherData.Split(' ');
                if (parts.Length < 2 || !parts[1].Contains("°C"))
                {
                    Console.WriteLine($"Weather in {city}: {weatherData}");
                    return;
                }

                // Extract temperature in Celsius and convert to Fahrenheit
                var tempCelsius = double.Parse(parts[1].Replace("°C", ""));
                var tempFahrenheit = (tempCelsius * 9 / 5) + 32;

                // Check if the console supports ANSI escape codes
                if (Console.OutputEncoding.CodePage == 65001) // UTF-8 encoding
                {
                    // ASCII art with colors
                    Console.WriteLine("\u001b[33m   \\   /      \u001b[0m");
                    Console.WriteLine("\u001b[33m    .-.       \u001b[0m");
                    Console.WriteLine("\u001b[33m ― (   ) ―    \u001b[0m");
                    Console.WriteLine("\u001b[33m    `-’       \u001b[0m");
                    Console.WriteLine("\u001b[33m   /   \\      \u001b[0m");

                    // Add a sun emoji if the temperature is over 70°F
                    if (tempFahrenheit > 70)
                    {
                        Console.WriteLine("\u001b[31m☀️  It's warm outside! ☀️\u001b[0m");
                    }
                }
                else
                {
                    // Fallback ASCII art without colors
                    Console.WriteLine("   \\   /      ");
                    Console.WriteLine("    .-.       ");
                    Console.WriteLine(" ― (   ) ―    ");
                    Console.WriteLine("    `-’       ");
                    Console.WriteLine("   /   \\      ");

                    if (tempFahrenheit > 70)
                    {
                        Console.WriteLine("☀️  It's warm outside! ☀️");
                    }
                }

                Console.WriteLine($"Weather in {city}: {weatherData}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather data: {ex.Message}");
            }
        }
    }
}