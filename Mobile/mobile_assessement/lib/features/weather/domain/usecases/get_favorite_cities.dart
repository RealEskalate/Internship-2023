
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/core/usecase/usecase.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';

import 'package:dartz/dartz.dart';

class GetFavoriteCities implements UseCase<List<String>, NoParams> {
  final WeatherRepository repository;

  GetFavoriteCities({required this.repository});

  @override
  Future<Either<Failure, List<String>>> call(NoParams params) async {
    final favoriteCities = await repository.getFavoriteCities();
    return favoriteCities;
  }
}