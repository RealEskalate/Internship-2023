import 'dart:convert';
import 'package:http/http.dart' as http;

import '../../core/errors/exceptions.dart';
import '../model/weather_model.dart';


abstract class WeatherRemoteDataSource {
  Future<WeatherModel> getWeatherByCity(String city);
}

class WeatherRemoteDataSourceImpl implements WeatherRemoteDataSource {
  final http.Client client;
  final String apiKey = '7d197f528a0548e085e123715232205';
 // Replace with your API key

  WeatherRemoteDataSourceImpl({required this.client});

  @override
  Future<WeatherModel> getWeatherByCity(String city) async {
    final url = Uri.parse('https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=$apiKey&q=$city&format=JSON');
    try {
      final response = await client.get(url);

      if (response.statusCode == 200) {
        final jsonBody = json.decode(response.body);
        return WeatherModel.fromJson(jsonBody);
      } else {
        throw InputException('Failed to fetch weather data');
      }
    } catch (e) {
      throw ServerException('Failed to fetch weather data');
    }
  }
}
