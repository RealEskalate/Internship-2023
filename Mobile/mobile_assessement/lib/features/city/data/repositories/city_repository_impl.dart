import '../../domain/entities/city_entity.dart';
import '../../domain/repositories/get_city_weather.dart';
import '../datasources/city_remote_datasources.dart';

class CityRepositoryImpl implements CityRepository {
  final CityRemoteDataSource remoteDataSource;

  CityRepositoryImpl({required this.remoteDataSource});

  @override
  Future<City> getCityWeather(String cityName) async {
    return await remoteDataSource.getCityWeather(cityName);
  }
}
