import 'package:mobile_assessement/features/home/domain/entities/city.dart';

abstract class CitySearchRepository {
  Future<City> searchCity(String cityName);
}
