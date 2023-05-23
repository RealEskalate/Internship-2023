import 'dart:convert';
import 'package:http/http.dart' as http;

class WeatherRemoteDataSource {
  final String apiKey = '7d197f528a0548e085e123715232205';



  Future<Map<String, dynamic>> getWeather(String cityName) async {
    final url =
        'https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=$apiKey&q=$cityName&format=json';
    final response = await http.get(url as Uri);

    if (response.statusCode == 200) {
      final decoded = json.decode(response.body);
      return decoded;
    } else {
      throw Exception('Failed to load weather data');
    }
  }
}

