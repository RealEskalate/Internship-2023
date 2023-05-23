
import 'package:mobile_assessement/features/weather_details/domain/entities/weather.dart';

abstract class WeatherRepository {
  Future<List<Weather>> getWeeklyWeather(String cityName);
}
