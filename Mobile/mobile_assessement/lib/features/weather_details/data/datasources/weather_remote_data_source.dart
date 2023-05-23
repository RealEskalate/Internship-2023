import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/features/weather_details/data/models/weather_model.dart';

abstract class WeatherRemoteDataSource {
  Future<List<WeatherModel>> getWeeklyWeather(String cityName);
}

class WeatherRemoteDataSourceImpl implements WeatherRemoteDataSource {
  final String apiKey = '7d197f528a0548e085e123715232205';

  @override
  Future<List<WeatherModel>> getWeeklyWeather(String cityName) async {
    final url =
        'https://api.worldweatheronline.com/premium/v1/weather.ashx?key=$apiKey&q=$cityName&format=JSON';
    final response = await http.get(Uri.parse(url));
    final data = jsonDecode(response.body);

    final weeklyWeather = data['data']['weather'] as List<dynamic>;

    return weeklyWeather.map((weather) {
      return WeatherModel(
        date: weather['date'],
        condition: weather['weatherCode'],
        temperature: weather['tempC'],
        humidity: weather['humidity'],
        windSpeed: weather['windspeedKmph'],
      );
    }).toList();
  }
}