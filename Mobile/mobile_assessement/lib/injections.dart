import 'package:get_it/get_it.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/usecases/get_current_weather.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/usecases/get_weather_forcast.dart';
import 'package:http/http.dart' as http;

import 'features/weather_forcast/data/datasources/weather_remote_data_source.dart';
import 'features/weather_forcast/data/repositories/weather_reposiotry_implementation.dart';
import 'features/weather_forcast/domain/repositories/weather_repository.dart';
import 'features/weather_forcast/presentation/bloc/weather_bloc.dart';

final sl = GetIt.instance;
Future<void> init() async {
//Bloc
  sl.registerFactory(
      () => WeatherBloc(getCurrentWeather: sl(), getWeatherForecast: sl()));
// uscases
  sl.registerLazySingleton(() => GetCurrentWeather(repository: sl()));
  sl.registerLazySingleton(() => GetWeatherForecast(repository: sl()));

//Repository

  sl.registerLazySingleton<WeatherRepository>(
      () => WeatherRepositoryImplementation(remoteDataSource: sl()));
//Data sources
  sl.registerLazySingleton<WeatherRemoteDataSource>(
      () => WeatherRemoteDataSourceImplementation(client: sl()));

// ignore: non_constant_identifier_names
  sl.registerLazySingleton(() => http.Client());
}
