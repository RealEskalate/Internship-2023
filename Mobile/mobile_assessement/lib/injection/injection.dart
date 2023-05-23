import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:http/http.dart' as http;

import '../core/network/network_info.dart';
import '../features/weather/data/datasources/weather_remote_datasource.dart';
import '../features/weather/domain/repositories/weather_repo.dart';
import '../features/weather/domain/usecases/get_fav_city.dart';
import '../features/weather/domain/usecases/get_weather.dart';
import '../features/weather/domain/usecases/search.dart';


final sl = GetIt.instance;

Future<void> weatherInit() async {
  // sl.registerFactory(() => WeatherBloc(searchCity: sl(), GetWeather: sl(), GetFavCity: sl()));

  // Use cases
  sl.registerLazySingleton(() => GetWeather(sl()));
  sl.registerLazySingleton(() => GetFavCity(sl()));
  sl.registerLazySingleton(() => searchCity(sl()));

  // Repository
  sl.registerLazySingleton<WeatherRepository>(
    () =>WeatherRepositoryImpl(WeatherRemoteDataSource: sl(), networkInfo: sl()));
  // Data sources
  sl.registerLazySingleton<WeatherRemoteDataSource>(
    () => WeatherRemoteDataSourceImpl(client: sl()),
  );


  // Core
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

  // External
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());
}