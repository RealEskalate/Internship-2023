import '../model/city_weather_model.dart';

abstract class WeatherLocalDataSource {
  /// Gets the cached [List<cityModel>] which was gotten the last time
  /// the user had an internet connection.
  ///
  /// Throws [CacheException] if no cached data is present.
  Future<List<CityWeatherDetailModel>> getcities();

  Future<void> cacheCity(CityWeatherDetailModel cityToCache);
}

class WeatherLocalDataSourceImpl implements WeatherLocalDataSource {
  @override
  Future<void> cacheCity(CityWeatherDetailModel cityToCache) {
    // TODO: implement cacheCity
    throw UnimplementedError();
  }

  @override
  Future<List<CityWeatherDetailModel>> getcities() {
    // TODO: implement getcities
    throw UnimplementedError();
  }
 
}
