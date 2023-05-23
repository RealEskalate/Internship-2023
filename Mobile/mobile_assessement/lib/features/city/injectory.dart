import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'data/datasources/city_remote_datasources.dart';
import 'data/repositories/city_repository_impl.dart';
import 'domain/repositories/city_repository.dart';
import 'domain/usecases/city_usecase.dart';

final sl = GetIt.instance;

void init() {
  // Register http client
  sl.registerLazySingleton(() => http.Client());

  // Register CityWeatherRemoteDataSource
  sl.registerLazySingleton<CityWeatherRemoteDataSource>(
    () => CityWeatherRemoteDataSourceImpl(httpClient: sl()),
  );

  // Register CityWeatherRepository
  sl.registerLazySingleton<CityWeatherRepository>(
    () => CityWeatherRepositoryImpl(remoteDataSource: sl()),
  );

  // Register GetCityWeather use case as a factory
  sl.registerFactory(() => GetCityWeather(sl()));
}
