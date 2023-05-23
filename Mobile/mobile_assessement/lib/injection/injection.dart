import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/features/weather/data/datasource/weather_local_datasource.dart';
import 'package:mobile_assessement/features/weather/data/datasource/weather_remote_datasource.dart';
import 'package:mobile_assessement/features/weather/data/repositories/weather_repository_impl.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/add_favorite_city.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_city_weather.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_favorite_cities.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/remove_favorite_city.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/bloc/weather_bloc_bloc.dart';
import 'package:shared_preferences/shared_preferences.dart';

final sl = GetIt.instance;

void init() async {
  // Registering the GetCityWeather use case as a lazy singleton
  sl.registerLazySingleton(() => GetCityWeather(repository: sl()));
  sl.registerLazySingleton(() => AddFavoriteCity(repository: sl()));
  sl.registerLazySingleton(() => GetFavoriteCities(repository: sl()));
  sl.registerLazySingleton(() => RemoveFavoriteCity(repository: sl()));


  sl.registerLazySingleton<WeatherRepository>(
      () => WeatherRepositoryImpl(remoteDataSource: sl(), localDataSource: sl()));
  
  // Registering the WeatherRemoteDataSourceImpl as a lazy singleton
  sl.registerLazySingleton<WeatherRemoteDataSource>(() =>
      WeatherRemoteDataSourceImpl(
          client: sl(), apiKey: '7d197f528a0548e085e123715232205'));
    
  sl.registerLazySingleton<WeatherLocalDataSource>(() =>
      WeatherLocalDataSourceImpl(sharedPreferences: sl()));



  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  

  // Registering the WeatherBloc as a factory
  sl.registerFactory(() => WeatherBloc(
        getCityWeather: sl(),
        addFavoriteCity: sl(),
        removeFavoriteCity: sl(),
        getFavoriteCities: sl(),
      ));

  // Registering the http client as a lazy singleton
  sl.registerLazySingleton(() => http.Client());
}
