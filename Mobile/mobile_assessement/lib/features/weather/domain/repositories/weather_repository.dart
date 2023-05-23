import '../entities/weather.dart';

abstract class WeatherRepository {
  Future<Weather> fetchWeather(String city);
  
}
