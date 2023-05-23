import 'package:shared_preferences/shared_preferences.dart';
import '../models/weather_model.dart';
import 'dart:convert';

abstract class LocalWeatherDataSource {
  Future<void> saveCity(String city);
  Future<String?> getCity();
  Future<void> saveWeather(WeatherModel weather);
  Future<WeatherModel?> getWeather(String city);
}

class LocalWeatherDataSourceImpl implements LocalWeatherDataSource {
  static const String keyCity = 'city';
  static const String keyWeather = 'weather';

  final SharedPreferences sharedPreferences;

  LocalWeatherDataSourceImpl(this.sharedPreferences);

  @override
  Future<void> saveCity(String city) async {
    await sharedPreferences.setString(keyCity, city);
  }

  @override
  Future<String?> getCity() async {
    return sharedPreferences.getString(keyCity);
  }

  @override
  Future<void> saveWeather(WeatherModel weather) async {
    final weatherJson = weather.toJson();
    await sharedPreferences.setString(keyWeather, json.encode(weatherJson));
  }

  @override
  Future<WeatherModel?> getWeather(String city) async {
    final weatherJson = sharedPreferences.getString(keyWeather);
    if (weatherJson != null) {
      final weatherData = json.decode(weatherJson);
      return WeatherModel.fromJson(weatherData);
    }
    return null;
  }
}
