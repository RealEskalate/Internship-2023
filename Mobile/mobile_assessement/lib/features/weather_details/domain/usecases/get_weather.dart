import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/core/usecases/usecases.dart';
import 'package:mobile_assessement/features/weather_details/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weather_details/domain/repositories/weather_repository.dart';

class GetWeeklyWeather extends UseCase<List<Weather>, String> {
  final WeatherRepository repository;

  GetWeeklyWeather(this.repository);

  @override
  Future<Either<Failure, List<Weather>>> call(String cityName) async {
    try {
      final weatherList = await repository.getWeeklyWeather(cityName);
      return right(weatherList);
    } catch (e) {
      return left(ServerFailure());
    }
  }
}