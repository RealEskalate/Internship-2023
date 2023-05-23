import 'package:get_it/get_it.dart';

import 'data/datasources/remote_data_souce.dart';
import 'data/repositories/repository_impl.dart';
import 'domain/repositories/repositories.dart';
import 'domain/usecase/get_weather_by_city.dart';
import 'presentation/bloc/weather_bloc.dart';
import 'package:http/http.dart' as http;
final locator = GetIt.instance;

void setupLocator() {
  // Register your dependencies

  locator.registerFactory<WeatherBloc>(() => WeatherBloc(getWeatherByCity: locator()));
  // WeatherRemoteDataSource
  locator.registerLazySingleton<http.Client>(() => http.Client());
  locator.registerLazySingleton<WeatherRemoteDataSource>(
    () => WeatherRemoteDataSourceImpl(client: locator()),
  );

  // WeatherRepository
  locator.registerLazySingleton<WeatherRepository>(
    () => WeatherRepositoryImpl(
      remoteDataSource: locator<WeatherRemoteDataSource>(),
    ),
  );

  // GetWeatherByCityUseCase
  locator.registerLazySingleton<GetWeatherByCity>(
    () => GetWeatherByCity(
      repository: locator<WeatherRepository>(),
    ),
  );

  // WeatherBloc
 
}
