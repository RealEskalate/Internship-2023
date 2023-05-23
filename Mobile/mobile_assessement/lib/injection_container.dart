

import 'package:get_it/get_it.dart';

import 'package:http/http.dart' as http;
import 'package:mobile_assessement/presentation/bloc/bloc/weather_bloc.dart';

import 'data/datasources/weather_remote_datasource.dart';
import 'data/repositories/weather_repo_impl.dart';
import 'domain/repositories/weather_repo.dart';
import 'domain/usecases/get_weather_data.dart';

final sl = GetIt.instance;
Future<void> userInjectionInit() async {
//Bloc
  sl.registerFactory(() => WeatherBloc(sl()));
// usecases
  sl.registerLazySingleton(() =>  GetWeatherData(sl()));
 
//Repository

  sl.registerLazySingleton<WeatherRepository>(() => WeatherDataRepositoryImpl(
      remoteDataSource: sl()));
//Data sources
  sl.registerLazySingleton<WeatherRemoteDataSource>(
      () => WeatherRemoteDataSourceImpl(client: sl()));

// ignore: non_constant_identifier_names
  
  sl.registerLazySingleton(() => http.Client());
}
