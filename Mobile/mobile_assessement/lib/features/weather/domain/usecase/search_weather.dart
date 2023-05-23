import '../repositories/weather_repository.dart';
import '../entities/weather.dart';

class SearchWeather {
  final WeatherRepository weatherRepository;

  SearchWeather(this.weatherRepository);

  Future<Weather> execute(String city) async {
    return await weatherRepository.fetchWeather(city);
  }
}