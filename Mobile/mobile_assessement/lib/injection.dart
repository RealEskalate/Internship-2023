import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/features/weather/data/datasources/weather_detail_remote_data_source.dart';
import 'package:mobile_assessement/features/weather/data/repositories/weather_repository_impl.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/weather_bloc.dart';

import '../core/network/network_info.dart';
import 'features/weather/domain/usecases/get_weather_detail.dart';


final sl = GetIt.instance;

Future<void> init() async {

  sl.registerFactory(() => WeatherBloc(getWeather: sl()));

  // Use cases
  sl.registerFactory(() => GetWeather(sl()));


  // Repository
  sl.registerLazySingleton<WeatherRepository>(
    () =>WeatherRepositoryImpl(networkInfo: sl(), remoteDataSource: sl()));


  // Data sources
  sl.registerLazySingleton<WeatherRemoteDataSource>(
    () => WeatherRemoteDataSourceImp(client: sl()),
  );


  // Core
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

  // External
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());
}