import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/features/weather/data/datasource/weather_remote_datasource.dart';
import 'package:mobile_assessement/features/weather/data/repositories/weather_repository_impl.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_city_weather.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/bloc/weather_bloc_bloc.dart';

final sl = GetIt.instance;

void init() {
  // Registering the GetCityWeather use case as a lazy singleton
  sl.registerLazySingleton(() => GetCityWeather(repository: sl()));

  // Registering the WeatherRemoteDataSourceImpl as a lazy singleton
  sl.registerLazySingleton<WeatherRemoteDataSource>(() =>
      WeatherRemoteDataSourceImpl(
          client: sl(), apiKey: '7d197f528a0548e085e123715232205'));

  // Registering the WeatherRepositoryImpl as a lazy singleton
  sl.registerLazySingleton<WeatherRepository>(
      () => WeatherRepositoryImpl(remoteDataSource: sl()));

  // Registering the WeatherBloc as a factory
  sl.registerFactory(() => WeatherBloc(
        getCityWeather: sl(),
        // addFavoriteCity: AddFavoriteCity(),
        // removeFavoriteCity: RemoveFavoriteCity(),
        // getFavoriteCities: GetFavoriteCities(),
      ));

  // Registering the http client as a lazy singleton
  sl.registerLazySingleton(() => http.Client());
}
