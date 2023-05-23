import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../../data/model/weather_model.dart';
import '../repository/weather_repository.dart';

class GetWeatherForCityUseCase {
  final WeatherRepository repository;

  GetWeatherForCityUseCase(this.repository);

  Future<Either<Failure, WeatherModel>> call(String city) async {
    return await repository.getWeatherForCity(city);
  }
}

class GetFavoriteWeatherUseCase {
  final WeatherRepository repository;

  GetFavoriteWeatherUseCase(this.repository);

  Future<Either<Failure, List<WeatherModel>>> call() async {
    return await repository.getFavoriteWeather();
  }
}

class SaveFavoriteCityUseCase {
  final WeatherRepository repository;

  SaveFavoriteCityUseCase(this.repository);

  Future<void> call(String city) async {
    await repository.saveFavoriteCity(city);
  }
}

class RemoveFavoriteCityUseCase {
  final WeatherRepository repository;

  RemoveFavoriteCityUseCase(this.repository);

  Future<void> call(String city) async {
    await repository.removeFavoriteCity(city);
  }
}
