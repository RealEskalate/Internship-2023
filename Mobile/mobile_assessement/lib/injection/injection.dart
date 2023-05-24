import 'package:get_it/get_it.dart';
import 'package:mobile_assessement/features/weatherify/data/data_source/weater_remote_data_source.dart';
import 'package:mobile_assessement/features/weatherify/data/repository/weather_repository_impl.dart';
import 'package:mobile_assessement/features/weatherify/domain/repository/weather_repository.dart';
import 'package:mobile_assessement/features/weatherify/domain/use_case/weather_use_case.dart';
import 'package:mobile_assessement/features/weatherify/presentation/bloc/bloc/weather_bloc.dart';
import 'package:http/http.dart' as http;

final sl = GetIt.instance;
void init() {
  sl.registerFactory(() => WeatherBloc(sl()));
  sl.registerFactory(() => GetWeatherForCity(sl()));
  sl.registerLazySingleton<WeatherRepository>(() => WeatherRepositoryImpl(
        weatherApiClient: sl(),
      ));

  sl.registerLazySingleton<WeatherRemoteDataSource>(
      ()=> WeatherRemoteDataSourceImpl(sl()));

  sl.registerLazySingleton(() => http.Client());
}
