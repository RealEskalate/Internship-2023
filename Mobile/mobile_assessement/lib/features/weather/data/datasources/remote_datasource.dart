import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/core/error/exception.dart';
import '../model/weather_model.dart';

class WeatherRemoteDataSource {
  final String baseUrl = 'https://api.weatherapi.com';
  final String apiKey = 'YOUR_API_KEY';

  Future<WeatherModel> getWeatherForCity(String city) async {
    final url = Uri.parse('$baseUrl/v1/current.json?key=$apiKey&q=$city');
    final response = await http.get(url);
    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      final weatherModel = WeatherModel.fromJson(data['current']);
      return weatherModel;
    } else {
      throw ServerException();
    }
  }
}
