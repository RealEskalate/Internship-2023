import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:meta/meta.dart';

import '../../../../core/error/exception.dart';
import '../models/weather_model.dart';

abstract class WeatherRemoteDataSource {
  Future<WeatherModel> getWeather(String city);
  Future<List<WeatherModel>> getFavouriteCity();
}

class WeatherRemoteDataSourceImpl implements WeatherRemoteDataSource {
  final http.Client client;
  String url =
      'https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=YOUR_API_KEY&q=[CITY_NAME]&format=JSON';

  WeatherRemoteDataSourceImpl({required this.client});

  @override
  Future<WeatherModel> getWeather(String city) async {
    final response = await client.get(
      Uri.parse(url.replaceFirst('[CITY_NAME]', city)),
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode == 200) {
      return WeatherModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }

  @override
  Future<List<WeatherModel>> getFavouriteCity() async {
    final response = await client.get(
      Uri.parse(url),
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      final favCityList = List<Map<String, dynamic>>.from(jsonResponse);
      final favCity =
          favCityList.map((json) => WeatherModel.fromJson(json)).toList();
      return favCity;
    } else {
      throw ServerException();
    }
  }

  @override
  Future<WeatherModel> searchCity(String city) async {
    final response = await client.get(
      Uri.parse(url.replaceFirst('[CITY_NAME]', city)),
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode == 200) {
      return WeatherModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }
}
