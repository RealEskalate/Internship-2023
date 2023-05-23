
import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/features/data/data_source/city_weather_remote_datasource.dart';
import 'package:mobile_assessement/features/data/repository/city_weather_repository_impl.dart';
import 'package:mobile_assessement/features/domain/entity/city_weather_entity.dart';
import 'package:mobile_assessement/features/domain/repository/weather_repository.dart';
import 'package:mobile_assessement/features/presentation/bloc/city_weather_bloc.dart';
import '../core/network/network_info.dart';

import 'features/domain/usecase/get_city_weather.dart';

final serviceLocator = GetIt.instance;

void init() {
  //! Features

  //?Bloc
  serviceLocator.registerFactory(() => CityWeatherBloc(serviceLocator()));

  //?Usecase
  serviceLocator.registerFactory(() => GetCityWeatherUseCase(serviceLocator()));

  //?Repositories
  serviceLocator.registerLazySingleton<WeatherRepository>(() =>
      WeatherRepositoryImpl(
          remotedataSource: serviceLocator(), networkInfo: serviceLocator()));
  //?DataSource

  serviceLocator.registerLazySingleton<WeatherRemoteDataSource>(
      () => WeatherRemoteDataSourceImpl(serviceLocator()));

  //! Core
  serviceLocator.registerLazySingleton<NetworkInfo>(
      () => NetworkInfoImpl(serviceLocator()));

  //! External
  serviceLocator.registerLazySingleton(() => http.Client());

  serviceLocator.registerLazySingleton(() => InternetConnectionChecker());
}