import '../models/weather_model.dart';
import '../data/datasources/weather_local_data_source.dart';
import '../data/datasources/weather_remote_data_source.dart';
import '../../domain/repositories/weather_repository.dart';

class WeatherRepositoryImpl implements WeatherRepository {
  final RemoteWeatherDataSource remoteDataSource;
  final LocalWeatherDataSource localDataSource;

  WeatherRepositoryImpl({
    required this.remoteDataSource,
    required this.localDataSource,
  });

  @override
  Future<WeatherModel> fetchWeather(String city) async {
    // Check if the weather data is available locally
    final cachedWeather = await localDataSource.getWeather(city);
    if (cachedWeather != null) {
      return cachedWeather;
    }

    // If not available locally, fetch weather data from the remote source
    final weather = await remoteDataSource.fetchWeather(city);

    // Save the fetched weather data locally
    await localDataSource.saveWeather(weather);

    return weather;
  }

  @override
  Future<void> saveCity(String city) async {
    await localDataSource.saveCity(city);
  }

  @override
  Future<String?> getCity() async {
    return localDataSource.getCity();
  }
}
