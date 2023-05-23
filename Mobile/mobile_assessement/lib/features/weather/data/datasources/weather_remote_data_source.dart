import 'dart:convert';

import 'package:http/http.dart' as http;
import '../models/weather_model.dart';

abstract class RemoteWeatherDataSource {
  Future<WeatherModel> fetchWeather(String city);
}

class RemoteWeatherDataSourceImpl implements RemoteWeatherDataSource {
  static const String baseUrl =
      'https://api.worldweatheronline.com/premium/v1/weather.ashx';
  static const String apiKey = '7d197f528a0548e085e123715232205';

  @override
  Future<WeatherModel> fetchWeather(String city) async {
    final url = Uri.parse('$baseUrl/?key=$apiKey&q=$city&format=JSON');
    final response = await http.get(url);

    if (response.statusCode == 200) {
      final jsonBody = json.decode(response.body);
      final data = jsonBody['data'];
      final currentCondition = data['current_condition'][0];
      final weatherDescription = currentCondition['weatherDesc'][0]['value'];
      final temperature = double.parse(currentCondition['temp_C']);
      final humidity = double.parse(currentCondition['humidity']);

      return WeatherModel(
        city: city,
        temperature: temperature,
        humidity: humidity,
        weatherDescription: weatherDescription,
      );
    } else {
      throw Exception('Failed to fetch weather data');
    }
  }
}