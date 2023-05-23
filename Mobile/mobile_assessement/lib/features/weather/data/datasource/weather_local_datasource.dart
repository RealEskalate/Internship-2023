import 'package:shared_preferences/shared_preferences.dart';

abstract class WeatherLocalDataSource {
  Future<List<String>> getFavoriteCities();
  Future<void> addFavoriteCity(String cityName);
  Future<void> removeFavoriteCity(String cityName);
}

class WeatherLocalDataSourceImpl implements WeatherLocalDataSource {
  final SharedPreferences sharedPreferences;

  WeatherLocalDataSourceImpl({required this.sharedPreferences});

  @override
  Future<List<String>> getFavoriteCities() async {
    final favoriteCities = sharedPreferences.getStringList('favorite_cities') ?? [];
    return favoriteCities;
  }

  @override
  Future<void> addFavoriteCity(String cityName) async {
    final favoriteCities = await getFavoriteCities();
    favoriteCities.add(cityName);
    await sharedPreferences.setStringList('favorite_cities', favoriteCities);
  }

  @override
  Future<void> removeFavoriteCity(String cityName) async {
    final favoriteCities = await getFavoriteCities();
    favoriteCities.remove(cityName);
    await sharedPreferences.setStringList('favorite_cities', favoriteCities);
  }
}