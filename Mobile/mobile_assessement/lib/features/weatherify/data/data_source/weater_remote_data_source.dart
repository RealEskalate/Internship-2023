import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/features/weatherify/data/models/weather_model.dart';

abstract class WeatherRemoteDataSource{

  Future<WeatherModel> getWeather(String cityName);
}

class WeatherRemoteDataSourceImpl implements WeatherRemoteDataSource {
  final String apiKey = '7d197f528a0548e085e123715232205';
  var client = http.Client();


  WeatherRemoteDataSourceImpl(this.client);

  @override
  Future<WeatherModel> getWeather(String cityName) async {
    final url =
        'https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=$apiKey&q=$cityName&format=json';
    final response = await client.get(Uri.parse(url));

    if (response.statusCode == 200) {
      final decoded = json.decode(response.body);
      return WeatherModel.fromJson(decoded);
    } else {
      throw Exception('Failed to load weather data');
    }
  }
  

}

