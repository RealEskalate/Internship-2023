import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/core/error_handle/exceptions.dart';
import 'package:mobile_assessement/data/model/weather.dart';



abstract class WeatherRemoteDataSource {
  Future<WeatherData> fetchWeatherData(String city);

  
}

class WeatherRemoteDataSourceImpl implements WeatherRemoteDataSource {
  @override
  Future<WeatherData> fetchWeatherData(String city) async {
  final Uri url = Uri.parse('https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=7d197f528a0548e085e123715232205&q=$city&format=JSON');
  final response = await http.get(url);
  if (response.statusCode == 200) {
    final jsonData = json.decode(response.body);
    return WeatherData.fromJson(jsonData);
  } else{
     final jsonData = json.decode(response.body);
    throw WeatherDataNotFoundException(jsonData['data']['error'][0]);
  }
}
}
