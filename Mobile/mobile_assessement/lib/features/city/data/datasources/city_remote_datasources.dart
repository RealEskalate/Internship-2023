import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../core/error/exceptions.dart';
import '../models/city_weather_model.dart';

abstract class CityWeatherRemoteDataSource {
  Future<CityWeatherModel> getCityWeather(String cityName);
}

class CityWeatherRemoteDataSourceImpl implements CityWeatherRemoteDataSource {
  final http.Client httpClient;

  CityWeatherRemoteDataSourceImpl({required this.httpClient});

  @override
  Future<CityWeatherModel> getCityWeather(String cityName) async {
    final apiKey = '7d197f528a0548e085e123715232205';
    final response = await httpClient.get(
      Uri.parse(
          'https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=$apiKey&q=$cityName&format=json'),
    );

    if (response.statusCode == 200) {
      final json = jsonDecode(response.body);
      final data = json['data'];
      final currentCondition = data['current_condition'][0];
      final weather = data['weather'][0];
      return CityWeatherModel(
        cityName: data['request'][0]['query'],
        oldestDate: weather['date'],
        avgTempc: double.parse(weather['avgtempC']),
        currentTempc: double.parse(currentCondition['temp_C']),
        weatherDescription: currentCondition['weatherDesc'][0]['value'],
        iconUrl: currentCondition['weatherIconUrl'][0]['value'],
      );
    } else {
      throw ServerException();
    }
  }
}
