import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:mobile_assessement/features/weatherify/data/models/weather_model.dart';

import '../../../../core/errors/exceptions.dart';

abstract class WeatherifyRemoteDataSource {
  Future<WeatherModel> searchCity(String cityName);
}

class WeatherifyRemoteDataSourceImpl implements WeatherifyRemoteDataSource {
  final http.Client client;
  String uri = "https://api";
  WeatherifyRemoteDataSourceImpl({required this.client});

  @override
  Future<WeatherModel> searchCity(String cityName) async {
    final  stringrui = Uri.parse(
   "https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=296bc9689b2d47ccbf6124612232205&q=california&format=JSON" );      
    print(stringrui);
    print("reached here sure");
    final response = await client.get(stringrui
          );
    print("response");
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      
      final weatherData = WeatherModel.fromJson(jsonResponse);
      return weatherData;
    } else if (response.statusCode == 404) {
      throw WeatherNotFoundException('Weather with ID $cityName not found');
    } else {
      throw ServerException(
          'Failed to get weather data with ID $cityName: ${response.reasonPhrase}');
    }
  }
}
