import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../core/error/exceptions.dart';
import '../model/city_weather_model.dart';

abstract class WeatherRemoteDataSource {
  Future<CityWeatherDetailModel> getCityWeather(String cityName);
}

class WeatherRemoteDataSourceImpl implements WeatherRemoteDataSource {
  final http.Client client;
  static const String apiKey = "c9b9bbc365e94423b34124714232205";

  WeatherRemoteDataSourceImpl({required this.client});

  @override
  Future<CityWeatherDetailModel> getCityWeather(String cityName) async {
    final url =
        'https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=$apiKey&q=$cityName&format=JSON';
    final response = await client.get(Uri.parse(url));
    if (response.statusCode == 200) {
      final jsonMap = json.decode(response.body);
      return CityWeatherDetailModel.fromJson(jsonMap['data']);
    } else {
      throw ServerException();
    }
  }
}
