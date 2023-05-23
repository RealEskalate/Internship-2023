import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/core/error/exceptions.dart';
import 'package:mobile_assessement/features/weather/data/model/weather_model.dart';
import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';

abstract class WeatherRemoteDataSource {
  Future<CityWeatherModel> getCityWeather(String cityName);
}

class WeatherRemoteDataSourceImpl implements WeatherRemoteDataSource {
  final http.Client client;
  final String apiKey;

  WeatherRemoteDataSourceImpl({required this.client, required this.apiKey});

  @override
  Future<CityWeatherModel> getCityWeather(String cityName) async {
    final url =
        'https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=$apiKey&q=$cityName&format=json';
    final response = await client.get(Uri.parse(url));
    if (response.statusCode == 200) {
      final json = jsonDecode(response.body);
      final data = json['data']['current_condition'][0];
      final cityWeather = CityWeatherModel.fromJson(data);
      return cityWeather;
    } else {
      throw ServerException();
    }
  }
}
