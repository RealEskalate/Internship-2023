import 'dart:convert';
import 'package:mobile_assessement/core/exceptions.dart';

import '../models/weather_model.dart';
import 'package:http/http.dart' as http;

abstract class WeatherRemoteDataSource {
  Future<WeatherModel> getWeather(String cityName);
}

class WeatherRemoteDataSourceImpl implements WeatherRemoteDataSource {
  final http.Client client;
  final uriString = '';

  WeatherRemoteDataSourceImpl({required this.client});

  @override
  Future<WeatherModel> getWeather(String cityName) async {
    final response = await client.get(
        Uri.parse(
            'https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=7d197f528a0548e085e123715232205&q=$cityName&format=JSON'),
        headers: {
          'Content-Type': 'application/json',
        });
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      return WeatherModel.fromJson(jsonResponse);
    } else {
      throw ServerException('Internal Server Failure');
    }
  }
}
