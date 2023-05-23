import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/core/usecase/usecase.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';
import 'package:dartz/dartz.dart';

class RemoveFavoriteCity implements UseCase<void, String> {
  final WeatherRepository repository;

  RemoveFavoriteCity({required this.repository});

  @override
  Future<Either<Failure, void>> call(String cityName) async {
    final result =await repository.removeFavoriteCity(cityName);
    return result;
  }
}