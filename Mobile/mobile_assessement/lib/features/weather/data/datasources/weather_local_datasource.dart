// import 'dart:convert';
// import 'package:shared_preferences/shared_preferences.dart';
// import '../models/weather_model.dart';

// abstract class WeatherLocalDataSource {
//   Future<List<WeatherModel>> getSavedCities();
//   Future<void> cacheWeathers(WeatherModel weather, String City);
// }

// const CACHED_CITIES = 'CACHED_CITIES';

// class WeatherLocalDataSourceImpl implements WeatherLocalDataSource {
//   final SharedPreferences sharedPreferences;
//   WeatherLocalDataSourceImpl({required this.sharedPreferences});

//   Future<List<WeatherModel>> getSavedCities() {
//     final jsonString = sharedPreferences.getString(CACHED_CITIES);
//     if (jsonString != null) {
//       final List<dynamic> jsonData = json.decode(jsonString);
//       final List<Weathe
//     }
//   }
// }
