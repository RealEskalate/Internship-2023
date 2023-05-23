import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/weatherify/domain/repository/weather_repository.dart';

import '../../../../core/errors/failures.dart';
import '../../../../core/use_cases/use_case.dart';
import '../entity/weather_entity.dart';


class GetWeatherForCity implements UseCase<Weather, String> {
  final WeatherRepository repository;

  GetWeatherForCity(this.repository);
  @override
  Future<Either<Failure, Weather>> call(String city) async {
    return await repository.getWeatherForCity(city);
  }
}
