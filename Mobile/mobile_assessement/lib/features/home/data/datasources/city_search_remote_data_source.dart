import 'package:mobile_assessement/features/home/data/models/city_model.dart';
import 'dart:convert';

import 'package:http/http.dart' as http;

abstract class CitySearchRemoteDataSource {
  Future<CityModel> searchCity(String cityName);
}


class CitySearchRemoteDataSourceImpl implements CitySearchRemoteDataSource {
  final String apiKey = '7d197f528a0548e085e123715232205';

  @override
  Future<CityModel> searchCity(String cityName) async {
    final url =
        'https://api.worldweatheronline.com/premium/v1/weather.ashx?key=$apiKey&q=$cityName&format=JSON';
    final response = await http.get(Uri.parse(url));
    final data = jsonDecode(response.body);

    final city = data['data']['request'][0]['query'];

    return CityModel(name: city);
  }
}