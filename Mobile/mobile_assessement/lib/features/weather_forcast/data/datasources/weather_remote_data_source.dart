import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:mobile_assessement/core/errors/exceptions.dart';
import 'package:mobile_assessement/features/weather_forcast/data/models/weather_forcast_model.dart';
import 'package:mobile_assessement/features/weather_forcast/data/models/weather_model.dart';

abstract class WeatherRemoteDataSource {
  Future<WeatherModel> getCurrentWeather(String city);
  Future<WeatherForecastModel> getWeatherForecast(String city);
}

class WeatherRemoteDataSourceImplementation implements WeatherRemoteDataSource {
  final http.Client client;
  String apiKey = "b0af9f62d335367e413b20b54012b91b";
  WeatherRemoteDataSourceImplementation({required this.client});

  @override
  Future<WeatherModel> getCurrentWeather(String city) async {
    final response = await client.get(Uri.parse(
        'https://api.openweathermap.org/data/2.5/weather?q=$city&appid=$apiKey'));
    if (response.statusCode == 200) {
      return WeatherModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException("Server Error");
    }
  }

  @override
  Future<WeatherForecastModel> getWeatherForecast(String city) async {
    final response = await client.get(Uri.parse(
        'https://api.openweathermap.org/data/2.5/forecast?q=$city&appid=$apiKey'));
    if (response.statusCode == 200) {
      return WeatherForecastModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException("Server Error");
    }
  }
}
