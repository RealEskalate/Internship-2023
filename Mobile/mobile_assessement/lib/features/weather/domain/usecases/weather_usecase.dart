import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/city_weather.dart';
import '../repository/weather_repository.dart';

class GetCityWeather implements UseCase<CityWeatherDetail, Params> {
  final WeatherRepository repository;

  GetCityWeather(this.repository);

  @override
  Future<Either<Failure, CityWeatherDetail>> call(Params params) async {
    return await repository.getCityWeather(params.cityName);
  }
}

class Params extends Equatable {
  final String cityName;

  Params({required this.cityName});

  @override
  List<Object?> get props => [cityName];
}
