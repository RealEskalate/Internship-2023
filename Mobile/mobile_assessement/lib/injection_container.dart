import 'package:get_it/get_it.dart';
import 'package:mobile_assessement/features/weatherify/data/datasources/weatherify_remote_data_source.dart';
import 'package:mobile_assessement/features/weatherify/data/repositories/weather_repository_impl.dart';
import 'package:mobile_assessement/features/weatherify/domain/repositories/weatherify_repository.dart';
import 'package:mobile_assessement/features/weatherify/domain/usecases/search_city.dart';
import 'package:mobile_assessement/features/weatherify/presentation/bloc/weatherify_bloc.dart';
import 'package:http/http.dart' as http;

final sl = GetIt.instance;
Future<void> init() async {
//Bloc
  sl.registerFactory(() => WeatherBloc(searchCity: sl()));
// usecases
  sl.registerLazySingleton(() => SearchCity(repo: sl()));

//Repository

  sl.registerLazySingleton<WeatherifyRepository>(() => WeatherifyRepositoryImpl(
      remoteDataSource: sl()));
//Data sources
  sl.registerLazySingleton<WeatherifyRemoteDataSource>(
      () => WeatherifyRemoteDataSourceImpl(client: sl()));

// ignore: non_constant_identifier_names
  // final sharedPreferences = await SharedPreferences.getInstance();
  // sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => http.Client());
}
