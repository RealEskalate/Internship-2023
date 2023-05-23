
import 'dart:convert';



import '../../../core/error/exception.dart';

import '../model/city_weather_model';
import 'package:http/http.dart' as http;
abstract class WeatherRemoteDataSource {
  Future<WeatherModel> getCityWeather(String cityName);
}

class WeatherRemoteDataSourceImpl implements WeatherRemoteDataSource {
  final baseUrl = 'https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=7d197f528a0548e085e123715232205&q=New%20Mexico&format=JSON';
  final apiKey = 'your_api_key_here';
  final http.Client client;

  WeatherRemoteDataSourceImpl(this.client);

  @override
  Future<WeatherModel> getCityWeather(String cityName) async {
    try {
      var response = await client.get(Uri.parse('$baseUrl$cityName&appid=$apiKey'));

      var decodedResponse =
          jsonDecode(utf8.decode(response.bodyBytes)) as Map<String, dynamic>;

      return WeatherModel.fromJson(decodedResponse);
    } on Exception catch (_, e) {
      throw ServerException();
    }
  }
}

