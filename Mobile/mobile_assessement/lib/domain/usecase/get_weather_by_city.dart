

// import '../entities/weather.dart';

import 'package:dartz/dartz.dart';

import '../../core/errors/failur.dart';
import '../../core/usecase/usecase.dart';
import '../entities/weather.dart';
import '../repositories/repositories.dart';

class GetWeatherByCity implements UseCase<Weather, String> {
  final WeatherRepository repository;

  GetWeatherByCity(this.repository);

  @override
  Future<Either<Failure, Weather>> call(String city) async {
    return await repository.getWeatherByCity(city);
  }
}
