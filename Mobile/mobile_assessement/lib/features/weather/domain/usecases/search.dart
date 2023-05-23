import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../repositories/weather_repo.dart';

class searchCity extends UseCase<Weather, String> {
  final WeatherRepository repository;

  searchCity(this.repository);

  @override
  Future<Either<Failure, Weather>> call(String city) async {
    return await repository.searchCity(city);
  }
}

