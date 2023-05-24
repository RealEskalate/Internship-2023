import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'data/datasources/city_remote_datasources.dart';
import 'data/repositories/city_repository_impl.dart';
import 'domain/repositories/get_city_weather.dart';
import 'domain/usecases/get_city_weather_usecase.dart';

GetIt sl = GetIt.instance;
void init() {
  // Register GetCityWeather use case as a factory
  sl.registerFactory(() => GetCityWeatherUseCase(repository: sl()));
  // Register http client
  sl.registerLazySingleton(() => http.Client());

  // Register CityWeatherRemoteDataSource
  sl.registerLazySingleton<CityRemoteDataSource>(
    () => CityRemoteDataSourceImpl(httpClient: sl()),
  );

  // Register CityWeatherRepository
  sl.registerLazySingleton<CityRepository>(
    () => CityRepositoryImpl(remoteDataSource: sl()),
  );
}
