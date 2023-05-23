import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/core/usecase/usecase.dart';
import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';
import 'package:dartz/dartz.dart';
import 'package:meta/meta.dart';

import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/core/usecase/usecase.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';

class GetCityWeather implements UseCase<CityWeather, String> {
  final WeatherRepository repository;

  GetCityWeather({required this.repository});

  @override
  Future<Either<Failure, CityWeather>> call(String cityName) async {
    final cityWeather = await repository.getCityWeather(cityName);
    return cityWeather;
  }
}