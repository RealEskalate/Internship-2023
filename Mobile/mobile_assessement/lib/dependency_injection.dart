import 'package:get_it/get_it.dart';
import 'package:mobile_assessement/features/weather/data/datasources/weather_remote_datasource.dart';
import 'package:mobile_assessement/features/weather/data/repositories/weather_repository_impl.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;

import 'features/weather/domain/usecases/get_weather.dart';
import 'features/weather/presentation/bloc/weather_bloc.dart';

final sl = GetIt.instance;

Future<void> weatherInjectionInit() async {
  // bloc
  sl.registerFactory(
    () => WeatherBloc(getWeather: sl()),
  );

  // usecasess

  sl.registerLazySingleton(
    () => GetWeather(repository: sl()),
  );

  // Repository

  sl.registerLazySingleton<WeatherRepository>(
    () => WeatherRepositoryImpl(remoteDataSource: sl()),
  );

  // Data Sources

  sl.registerLazySingleton<WeatherRemoteDataSource>(
    () => WeatherRemoteDataSourceImpl(client: sl()),
  );

  //external
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => http.Client());
}
