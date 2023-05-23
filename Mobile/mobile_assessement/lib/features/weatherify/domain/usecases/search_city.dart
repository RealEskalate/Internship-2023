import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/weatherify/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weatherify/domain/repositories/weatherify_repository.dart';

import '../../../../core/errors/failure.dart';
import '../../../../core/usecases/usecase.dart';

class SearchCity implements UseCase<Weather, String> {
  final WeatherifyRepository repo;
  SearchCity({required this.repo});

  @override
  Future<Either<Failure, Weather>> call(String id) async {
    return await repo.searchCity(id);
  }
}
