import 'dart:convert';

import 'package:mobile_assessement/core/error/exception.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../model/weather_model.dart';

class WeatherLocalDataSource {
  static const String favoriteCitiesKey = 'favoriteCities';

  Future<void> addFavoriteCity(String city) async {
    final prefs = await SharedPreferences.getInstance();
    final favoriteCities = prefs.getStringList(favoriteCitiesKey) ?? [];
    if (!favoriteCities.contains(city)) {
      favoriteCities.add(city);
      await prefs.setStringList(favoriteCitiesKey, favoriteCities);
    }
  }

  Future<void> removeFavoriteCity(String city) async {
    final prefs = await SharedPreferences.getInstance();
    final favoriteCities = prefs.getStringList(favoriteCitiesKey) ?? [];
    favoriteCities.remove(city);
    await prefs.setStringList(favoriteCitiesKey, favoriteCities);
  }

  Future<List<String>> getFavoriteCities() async {
    final prefs = await SharedPreferences.getInstance();
    final favoriteCities = prefs.getStringList(favoriteCitiesKey) ?? [];
    return favoriteCities;
  }

  Future<void> cacheWeatherData(WeatherModel weather) async {
    final prefs = await SharedPreferences.getInstance();
    prefs.setString(weather.city, weather.toString());
  }

  Future<WeatherModel> getCachedWeatherData(String city) async {
    final prefs = await SharedPreferences.getInstance();
    final jsonString = prefs.getString(city);
    if (jsonString != null) {
      return WeatherModel.fromJson(jsonDecode(jsonString));
    }
    throw CacheException();
  }
}
