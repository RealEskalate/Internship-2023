import '../entities/city.dart';

abstract class CitiesRepository {
  Future<List<CityWeather>> getCities();
}
