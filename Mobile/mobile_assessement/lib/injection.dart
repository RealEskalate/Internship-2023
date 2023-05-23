import 'package:get_it/get_it.dart';
import "package:http/http.dart" as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:mobile_assessement/features/weather/data/datasource/weather_remote_datasource.dart';
import 'package:mobile_assessement/features/weather/domain/repository/weather_repository.dart';

import 'core/network/network_info.dart';
import 'features/weather/data/datasource/weather_local_datasource.dart';
import 'features/weather/data/repository/weather_repository.dart';
import 'features/weather/domain/usecases/weather_usecase.dart';
import 'features/weather/presentation/bloc/weather_bloc.dart';

final sl = GetIt.instance;

Future<void> init() async {
  sl.registerFactory(() => WeatherBloc(sl()));

  // Use cases
  sl.registerLazySingleton(() => GetCityWeather(sl()));

  // Repository
  sl.registerLazySingleton<WeatherRepository>(() => WeatherRepositoryImpl(
      remoteDataSource: sl(), localDataSource: sl(), networkInfo: sl()));
  // Data sources
  sl.registerLazySingleton<WeatherRemoteDataSource>(
    () => WeatherRemoteDataSourceImpl(client: sl()),
  );

  sl.registerLazySingleton<WeatherLocalDataSource>(
    () => WeatherLocalDataSourceImpl(),
  );
  
  

  // Core
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

  // External
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());
}
