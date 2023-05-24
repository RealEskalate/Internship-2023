import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/core/error/exception.dart';
import '../model/weather_model.dart';

class WeatherRemoteDataSource {
  final String baseUrl =
      'https://api.worldweatheronline.com/premium/v1/weather.ashx';
  final String apiKey = '7d197f528a0548e085e123715232205';

  Future<WeatherModel> getWeatherForCity(String city) async {
    final url = Uri.parse('$baseUrl/?key=$apiKey&q=$city&format=JSON');
    // print(url);
    final response = await http.get(url);
    if (response.statusCode == 200) {
      final data =
          jsonDecode(utf8.decode(response.bodyBytes)) as Map<String, dynamic>;

      final weatherModel = WeatherModel.fromJson(data['data']);
      return weatherModel;
    } else {
      throw ServerException();
    }
  }
}
