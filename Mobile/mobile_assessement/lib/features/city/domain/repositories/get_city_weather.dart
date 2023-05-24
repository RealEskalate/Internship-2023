import '../entities/city_entity.dart';

abstract class CityRepository {
  Future<City> getCityWeather(String cityName);
}
